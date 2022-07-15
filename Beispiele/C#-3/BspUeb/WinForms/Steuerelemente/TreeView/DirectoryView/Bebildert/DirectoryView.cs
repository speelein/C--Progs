// Klasse DirectoryView nach Petzold (2002, S.932ff)

using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

public class DirectoryView : TreeView 	{

	public DirectoryView() {
		DriveInfo[] drives = DriveInfo.GetDrives();
		int imageIndex;

		ImageList = new ImageList();
		ImageList.Images.AddStrip(Image.FromFile("dirview.bmp"));
		ImageList.TransparentColor = Color.Cyan;

		foreach (DriveInfo d in drives) {
			switch (d.DriveType) {
				case DriveType.Removable: imageIndex = 0; break;
				case DriveType.Fixed: imageIndex = 1; break;
				case DriveType.Network: imageIndex = 2; break;
				case DriveType.CDRom: imageIndex = 3; break;
				default: imageIndex = 4; break;
			}
			TreeNode tnDrive = new TreeNode(d.Name, imageIndex, imageIndex);
			Nodes.Add(tnDrive);
			if (d.Name == "A:\\" || d.Name == "C:\\")
			AddDirectories(tnDrive);
			if (d.Name == "C:\\")
				SelectedNode = tnDrive;
		}
	}
	
	void AddDirectories(TreeNode tn) {
		tn.Nodes.Clear();
		String[] dirs = {""};
		try {
			dirs = Directory.GetDirectories(tn.FullPath);
		} catch {
			return;
		}
		foreach (String s in dirs) {
			TreeNode tnDir = new TreeNode(Path.GetFileName(s), 5, 6);
			tn.Nodes.Add(tnDir);
			AddDirectories(tnDir);
		}
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Form frm = new Form();
		frm.Text = "DirectoryView - mit Laufwerkssymbolen";
		DirectoryView dv = new DirectoryView();
		dv.Parent = frm;
		dv.Dock = DockStyle.Fill;
		Application.Run(frm);
	}
}
