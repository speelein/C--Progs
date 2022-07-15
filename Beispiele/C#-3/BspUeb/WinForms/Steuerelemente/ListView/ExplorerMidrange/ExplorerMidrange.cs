using System;
using System.Drawing;
using System.Windows.Forms;

class ExplorerMidrange : Form {
	SplitContainer sc;
	DirectoryView dv;
	DirEntryList del;
	
	ExplorerMidrange() {
		sc = new SplitContainer();
		sc.Parent = this;
		sc.Dock = DockStyle.Fill;
		sc.SplitterWidth = 5;
		sc.BorderStyle = BorderStyle.Fixed3D;
		sc.FixedPanel = FixedPanel.Panel1;

		dv = new DirectoryView();
		dv.Parent = sc.Panel1;
		dv.Dock = DockStyle.Fill;
		dv.BorderStyle = BorderStyle.None;
		dv.AfterSelect += new TreeViewEventHandler(DirectoryViewOnAfterSelect);

		del = new DirEntryList(dv.SelectedNode.FullPath);
		del.Parent = sc.Panel2;
		del.Dock = DockStyle.Fill;
	}
	
	void DirectoryViewOnAfterSelect(object sender, TreeViewEventArgs tvea) {
		String s = tvea.Node.FullPath.Replace(@"\\", @"\"); // Sinnvoll wg. Pfadnamen wie "G:\\Bib"
		del.ShowEntries(s);
		Text = s;
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new ExplorerMidrange());
	}
}
