// Klasse DirEntryList nach Petzold (2003, S. 952ff)

using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

public class DirEntryList : ListView {
	String strDir;

	public DirEntryList(String dir) {
		Dir = dir;
		View = View.Details;
		Sorting = SortOrder.Ascending;
		Columns.Add("Name", 120, HorizontalAlignment.Left);
		Columns.Add("Gr??e", 120, HorizontalAlignment.Left);
		Columns.Add("Letzte ?nderung", 120, HorizontalAlignment.Left);
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
			ListViewItem lvi = new ListViewItem(di.Name);
			lvi.SubItems.Add("");
			lvi.SubItems.Add(di.LastWriteTime.ToString());
			Items.Add(lvi);
		}

		FileInfo[] afi;
		try {
			afi = directoryInfo.GetFiles();
		} catch {
			return;
		}
		foreach (FileInfo fi in afi) {
			ListViewItem lvi = new ListViewItem(fi.Name);
			lvi.SubItems.Add(fi.Length.ToString());
			lvi.SubItems.Add(fi.LastWriteTime.ToString());
			Items.Add(lvi);
		}

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

	public static void Main() {
		Form frm = new Form();
		frm.Text = "DirEntryList-Demo";
		DirEntryList fv = new DirEntryList("C:\\");
		fv.Parent = frm;
		fv.Dock = DockStyle.Fill;
		fv.ShowEntries();
		Application.Run(frm);
	}
}
