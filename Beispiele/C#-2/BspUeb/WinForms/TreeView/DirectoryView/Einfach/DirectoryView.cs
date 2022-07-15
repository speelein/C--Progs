// Klasse DirectoryView nach Petzold (2003, S.932ff)

using System;
using System.IO;
using System.Windows.Forms;

public class DirectoryView : TreeView {

	public DirectoryView() {
		Nodes.Clear();
		String[] drives = Directory.GetLogicalDrives();
		foreach (String s in drives) {
			TreeNode tnDrive = new TreeNode(s);
			Nodes.Add(tnDrive);
			AddDirectories(tnDrive);
			if (s == "C:\\")
				SelectedNode = tnDrive;
		}
	}
	
	void AddDirectories(TreeNode tn) {
		tn.Nodes.Clear();
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
	
	public static void Main() {
		Form frm = new Form();
		frm.Text = "DirectoryViewDemo";
		DirectoryView dv = new DirectoryView();
		dv.Parent = frm;
		dv.Dock = DockStyle.Fill;
		Application.Run(frm);
	}
}
