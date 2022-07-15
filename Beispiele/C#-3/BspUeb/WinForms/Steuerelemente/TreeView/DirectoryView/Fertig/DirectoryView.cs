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
			AddDirectories(tnDrive);
			if (d.Name == "C:\\")
				SelectedNode = tnDrive;
		}
	}
	
	void AddDirectories(TreeNode tn) {
		String[] dirs = {""};
		try {
			dirs = Directory.GetDirectories(tn.FullPath);
		} catch {
			return;
		}
		TreeNode[] tna = new TreeNode[dirs.Length];
		for (int i = 0; i < dirs.Length; i++) {
			tna[i] = new TreeNode(Path.GetFileName(dirs[i]), 5, 6);
		}
		tn.Nodes.AddRange(tna);
	}

	override protected void OnBeforeExpand(TreeViewCancelEventArgs tvcea) {
		base.OnBeforeExpand(tvcea);
		BeginUpdate();
		tvcea.Node.Nodes.Clear();	// Eine vorhandene Liste von Unterknoten wird gelöscht, weil 
		AddDirectories(tvcea.Node);	// sie eventuell nicht mehr aktuell ist.
		foreach (TreeNode tn in tvcea.Node.Nodes)
			AddDirectories(tn);
		EndUpdate();
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Form frm = new Form();
		frm.Text = "DirectoryView - Fertig";
		DirectoryView dv = new DirectoryView();
		dv.Parent = frm;
		dv.Dock = DockStyle.Fill;
		Application.Run(frm);
	}
}