using System;
using System.Windows.Forms;
using System.Drawing;

class CheckedOnClick : Form {
	RichTextBox editor;
	ToolStripButton tsbBold;
	
	CheckedOnClick() {
		Text = "CheckedOnClick";
		editor = new RichTextBox();
		editor.Dock = DockStyle.Fill;
		Controls.Add(editor);
		tsbBold = new ToolStripButton();
		Bitmap bmp = new Bitmap("bold.bmp");
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		tsbBold.Image = bmp;
		tsbBold.CheckOnClick = true;
		tsbBold.CheckStateChanged += new
			System.EventHandler(TsbBoldOnCheckStateChanged);
		ToolStrip toolStrip = new ToolStrip();
		toolStrip.Items.Add(tsbBold);
		toolStrip.Dock = DockStyle.Top;
		Controls.Add(toolStrip);
	}

	protected void TsbBoldOnCheckStateChanged(object sender, EventArgs e) {
		if (tsbBold.Checked)
			editor.Font = new Font(editor.Font, editor.Font.Style | FontStyle.Bold);
		else
			editor.Font = new Font(editor.Font, editor.Font.Style & ~FontStyle.Bold);
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new CheckedOnClick());
	}
}