using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

public class ExplorerLight : Form {
	SplitContainer sc;
	DirectoryView dv;
	Panel fileList;
	
	public ExplorerLight() {
		Text = "Explorer Light";
		sc = new SplitContainer();
		sc.Parent = this;
		sc.Dock = DockStyle.Fill;
		sc.SplitterWidth = 5;
		sc.BorderStyle = BorderStyle.Fixed3D;
	
		dv = new DirectoryView();
		dv.Parent = sc.Panel1;
		dv.Dock = DockStyle.Fill;
		dv.BorderStyle = BorderStyle.None;
		dv.AfterSelect += new TreeViewEventHandler(DirectoryViewOnAfterSelect);

		sc.Panel2.AutoScroll = true;
		sc.Panel2.BackColor = SystemColors.Window;

		fileList = new Panel();
		fileList.Parent = sc.Panel2;
		fileList.Dock = DockStyle.Top;
		fileList.Height = sc.Panel2.Height;
		fileList.BackColor = SystemColors.Window;
		fileList.Paint += new PaintEventHandler(FileListOnPaint);
	}
	
	void DirectoryViewOnAfterSelect(object sender, TreeViewEventArgs tvea) {
		fileList.Invalidate();
	}
	
	void FileListOnPaint(object sender, PaintEventArgs e) {
		if (dv.SelectedNode == null)
			return;
		String[] files;
		try {
			files = Directory.GetFiles(dv.SelectedNode.FullPath);
		} catch {
			return;
		}
		int y = 5;
		foreach (String s in files) {
			e.Graphics.DrawString(Path.GetFileName(s), Font, SystemBrushes.WindowText, 5, y);
			y += Font.Height;
		}
		fileList.Height = y;
	}

	public static void Main() {
		Application.Run(new ExplorerLight());
	}
}