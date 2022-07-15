using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

class ExplorerLight : Form {
	SplitContainer splitCont;
	DirectoryView dirView;
	Panel fileList;
	
	ExplorerLight() {
		Text = "Explorer Light";
		splitCont = new SplitContainer();
		splitCont.Parent = this;
		splitCont.Dock = DockStyle.Fill;
		splitCont.SplitterWidth = 5;
		splitCont.BorderStyle = BorderStyle.Fixed3D;
	
		dirView = new DirectoryView();
		dirView.Parent = splitCont.Panel1;
		dirView.Dock = DockStyle.Fill;
		dirView.BorderStyle = BorderStyle.None;
		dirView.AfterSelect += new TreeViewEventHandler(DirectoryViewOnAfterSelect);

		splitCont.Panel2.AutoScroll = true;
		splitCont.Panel2.BackColor = SystemColors.Window;

		fileList = new Panel();
		fileList.Parent = splitCont.Panel2;
		fileList.Dock = DockStyle.Top;
		fileList.Height = splitCont.Panel2.Height;
		fileList.BackColor = SystemColors.Window;
		fileList.Paint += new PaintEventHandler(FileListOnPaint);
	}
	
	void DirectoryViewOnAfterSelect(object sender, TreeViewEventArgs tvea) {
		fileList.Refresh();
	}
	
	void FileListOnPaint(object sender, PaintEventArgs e) {
		if (dirView.SelectedNode == null)
			return;
		String[] files;
		try {
			files = Directory.GetFiles(dirView.SelectedNode.FullPath);
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

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new ExplorerLight());
	}
}