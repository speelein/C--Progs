using System;
using System.Drawing;
using System.Windows.Forms;

public class ExplorerMidrange : Form {
	SplitContainer sc;
	DirectoryView dv;
	DirEntryList del;
	
	public ExplorerMidrange() {
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
		String s = tvea.Node.FullPath.Replace("\\\\", "\\");
		del.ShowEntries(s);
		Text = s;
	}

	public static void Main() {
		Application.Run(new ExplorerMidrange());
	}
}
