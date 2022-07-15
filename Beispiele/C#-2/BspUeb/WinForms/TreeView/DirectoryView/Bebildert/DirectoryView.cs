// Klasse DirectoryView nach Petzold (2003, S.932ff)

using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

public class DirectoryView : TreeView 	{

	public DirectoryView() {
		Nodes.Clear();
		DriveInfo[] drives = DriveInfo.GetDrives();
		int imageIndex;
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
			AddDirectories(tnDrive);
			if (d.Name == "C:\\")
				SelectedNode = tnDrive;
		}
		ImageList = new ImageList();
		ImageList.Images.AddStrip(Image.FromFile("dirview.bmp"));
		ImageList.TransparentColor = Color.Cyan;
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
	
	public static void Main() {
		Form frm = new Form();
		frm.Text = "DirectoryViewDemo";
		DirectoryView dv = new DirectoryView();
		dv.Parent = frm;
		dv.Dock = DockStyle.Fill;
		Application.Run(frm);
	}
}
