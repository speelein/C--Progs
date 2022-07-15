// Klasse DirectoryView nach Petzold (2002, S.932ff)

using System;
using System.IO;
using System.Windows.Forms;

public class DirectoryView : TreeView {
	public DirectoryView() {
		String[] drives = Directory.GetLogicalDrives();
		foreach (String s in drives) {
			TreeNode tnDrive = new TreeNode(s);
			Nodes.Add(tnDrive);
			//if (s == "A:\\" || s == "C:\\")
			AddDirectories(tnDrive);
			if (s == "C:\\")
				SelectedNode = tnDrive;
		}
	}
	
	void AddDirectories(TreeNode tn) {
		String[] dirs;
		try {
			dirs = Directory.GetDirectories(tn.FullPath);
		} catch {
			return;
		}
		foreach (String s in dirs) {
			TreeNode tnDir = new TreeNode(Path.GetFileName(s));
			tn.Nodes.Add(tnDir);
			AddDirectories(tnDir);
		}
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles(); 
		Form frm = new Form();
		frm.Text = "DirectoryView - Einfach";
		DirectoryView dv = new DirectoryView();
		dv.Parent = frm;
		dv.Dock = DockStyle.Fill;
		Application.Run(frm);
	}
}
