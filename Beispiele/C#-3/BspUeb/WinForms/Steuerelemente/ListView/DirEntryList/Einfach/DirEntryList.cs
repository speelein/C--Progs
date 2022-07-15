// Klasse DirEntryList nach Petzold (2002, S. 952ff)

using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;

public class DirEntryList : ListView {
	String strDir;

	public DirEntryList(String dir) {
		strDir = dir;
		View = View.Details;
		Sorting = SortOrder.Ascending;
		Columns.Add("Name", 120, HorizontalAlignment.Left);
		Columns.Add("Größe", 120, HorizontalAlignment.Left);
		Columns.Add("Letzte Änderung", 120, HorizontalAlignment.Left);
		//Activation = ItemActivation.TwoClick;
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
		try {
			BeginUpdate();
			strDir = dir;
			Items.Clear();
			DirectoryInfo directoryInfo = new DirectoryInfo(dir);

			DirectoryInfo[] adi;
			adi = directoryInfo.GetDirectories();
			foreach (DirectoryInfo di in adi) {
				ListViewItem lvi = new ListViewItem(di.Name);
				lvi.SubItems.Add("");
				lvi.SubItems.Add(di.LastWriteTime.ToString());
				Items.Add(lvi);
			}

			FileInfo[] afi;
			afi = directoryInfo.GetFiles();
			foreach (FileInfo fi in afi) {
				ListViewItem lvi = new ListViewItem(fi.Name);
				lvi.SubItems.Add(fi.Length.ToString());
				lvi.SubItems.Add(fi.LastWriteTime.ToString());
				Items.Add(lvi);
			}
		} catch (Exception e) {
			MessageBox.Show(e.Message);
			return;
		} finally {
			EndUpdate();
		}
	}
	
	override protected void OnItemActivate(EventArgs ea) {
		base.OnItemActivate(ea);
		foreach (ListViewItem lvi in SelectedItems) {
			if (lvi.SubItems[1].Text == "") // Item ist Unterordner
				ShowEntries(Path.Combine(strDir, lvi.Text));
			else
				ThreadPool.QueueUserWorkItem(new WaitCallback(StartProcess), Path.Combine(strDir, lvi.Text));
		}
	}

	protected void StartProcess(object path) {
		try {
			System.Diagnostics.Process.Start((String)path);
		} catch {
			return;
		}
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Form frm = new Form();
		frm.Text = "DirEntryList - Einfach";
		DirEntryList fv = new DirEntryList("C:\\");
		fv.Parent = frm;
		fv.Dock = DockStyle.Fill;
		fv.ShowEntries();
		Application.Run(frm);
	}
}
