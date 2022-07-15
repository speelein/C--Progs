using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Globalization;

public class DirEntryList : ListView {
	String strDir;
	int sortCol;
	int[] sortOrderArray = {1, 1, 1};
	int sortOrder = 1;

	public DirEntryList(String dir) {
		Dir = dir;
		View = View.Details;

		DirEntryComparer dirEntryComparer = new DirEntryComparer(this);
		ListViewItemSorter = dirEntryComparer;

		Columns.Add("Name", 120, HorizontalAlignment.Left);
		Columns.Add("Größe", 120, HorizontalAlignment.Right);
		Columns.Add("Letzte Änderung", 120, HorizontalAlignment.Left);

		SmallImageList = new ImageList();
		SmallImageList.Images.AddStrip(Image.FromFile("direntry.bmp"));
		SmallImageList.TransparentColor = Color.Cyan;

		ColumnClick += new ColumnClickEventHandler(DirEntryListOnColumnClick);
	}

	public String Dir {
		get {
			return strDir;
		}
		set {
			if (Directory.Exists(value))
				strDir = value;
		}
	}

	public int SortCol {
		get {
			return sortCol;
		}
	}

	public int SortOrder {
		get {
			return sortOrder;
		}
	}

	public void ShowEntries() {
		ShowEntries(strDir);
	}

	public void ShowEntries(String dir) {
		if (!Directory.Exists(dir))
			return;
		strDir = dir;
		Items.Clear();
		DirectoryInfo directoryInfo = new DirectoryInfo(dir);

		DirectoryInfo[] adi;
		try {
			adi = directoryInfo.GetDirectories();
		} catch {
			return;
		}
		foreach (DirectoryInfo di in adi) {
			ListViewItem lvi = new ListViewItem(di.Name, 1);
			lvi.SubItems.Add("");
			lvi.SubItems.Add(di.LastWriteTime.ToString());
			lvi.Tag = di;
			Items.Add(lvi);
		}

		FileInfo[] afi;
		try {
			afi = directoryInfo.GetFiles();
		} catch {
			return;
		}
		foreach (FileInfo fi in afi) {
			ListViewItem lvi = new ListViewItem(fi.Name, 0);
			lvi.SubItems.Add(fi.Length.ToString());
			lvi.SubItems.Add(fi.LastWriteTime.ToString());
			lvi.Tag = fi;
			Items.Add(lvi);
		}
		Sort();
	}
	
	override protected void OnItemActivate(EventArgs ea) {
		base.OnItemActivate(ea);
		foreach (ListViewItem lvi in SelectedItems) {
			if (lvi.SubItems[1].Text == "")
				ShowEntries(Path.Combine(strDir, lvi.Text));
			else
				ThreadPool.QueueUserWorkItem(new WaitCallback(StartProcess), Path.Combine(strDir, lvi.Text));
		}
	}

	protected void StartProcess(object path) {
		try {
			Process.Start((String)path);
		} catch {
			return;
		}
	}

	public void DirEntryListOnColumnClick(Object sender, ColumnClickEventArgs ccea) {
		sortCol = ccea.Column;
		sortOrder = sortOrderArray[SortCol] *= -1;
		ShowEntries();
	}

	public static void Main() {
		Form frm = new Form();
		frm.Text = "DirEntryList-Demo";
		DirEntryList fv = new DirEntryList("C:\\");
		fv.Parent = frm;
		fv.Dock = DockStyle.Fill;
		fv.ShowEntries();
		Application.Run(frm);
	}

	public class DirEntryComparer : IComparer {
		DirEntryList del;
		Comparer comparer = new Comparer(CultureInfo.CurrentCulture);

		public DirEntryComparer(DirEntryList del_) {
			del = del_;
		}

		public int Compare(Object x, Object y) {
			ListViewItem lx = (ListViewItem) x;
			ListViewItem ly = (ListViewItem) y;
			String sx = lx.SubItems[0].Text.ToUpper();
			String sy = ly.SubItems[0].Text.ToUpper();
			bool xDir = lx.SubItems[1].Text == ""; // Ordner sind u.a. an der fehlenden Größenangabe zu erkennen.
			bool yDir = ly.SubItems[1].Text == "";
			if (xDir)
				if (yDir)
					switch (del.SortCol) {
						case 0: return del.SortOrder > 0 ? comparer.Compare(sx, sy) : comparer.Compare(sy, sx);
						case 1: return 0;
						case 2: return del.SortOrder > 0 ?
							comparer.Compare((lx.Tag as DirectoryInfo).LastWriteTime, (ly.Tag as DirectoryInfo).LastWriteTime):
							comparer.Compare((ly.Tag as DirectoryInfo).LastWriteTime, (lx.Tag as DirectoryInfo).LastWriteTime);
						default: return 0;
					}
				else {
					return del.SortOrder > 0 ? -1 : 1;
				}
			else
				if (yDir)
					return del.SortOrder > 0 ? 1 : -1;
				else
					switch (del.SortCol) {
						case 0: return del.SortOrder > 0 ? comparer.Compare(sx, sy) : comparer.Compare(sy, sx);
						case 1: return del.SortOrder > 0 ?
							comparer.Compare((lx.Tag as FileInfo).Length, (ly.Tag as FileInfo).Length) :
							comparer.Compare((ly.Tag as FileInfo).Length, (lx.Tag as FileInfo).Length);
						case 2: return del.SortOrder > 0 ?
							comparer.Compare((lx.Tag as FileInfo).LastWriteTime, (ly.Tag as FileInfo).LastWriteTime) :
							comparer.Compare((ly.Tag as FileInfo).LastWriteTime, (lx.Tag as FileInfo).LastWriteTime);
						default: return 0;
					}
		}
	}
}