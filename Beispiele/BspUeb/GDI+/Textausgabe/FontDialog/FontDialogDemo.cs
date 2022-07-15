using System;
using System.Windows.Forms;
using System.Drawing;

class FontDialogDemo : Form {
	Font font;
	string text;
	FontDialog fd = new FontDialog();

	public FontDialogDemo() {
		Text = "FontDialog-Demo";
		Size = new Size(250, 150);
		MinimumSize = new Size(250, 150);
		BackColor = SystemColors.Window;
		font = new Font("Arial", 12, FontStyle.Bold);
		text = font.Name;
		Button cbFont = new Button();
		cbFont.Text = "Schriftart wählen";
		cbFont.BackColor = SystemColors.Control;
		cbFont.Top = 20;
		cbFont.Left = 20;
		cbFont.Width = 200;
		cbFont.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		Controls.Add(cbFont);
		cbFont.Click += new EventHandler(ButtonOnClick);
	}

	protected void ButtonOnClick(object sender, EventArgs e) {
		if (fd.ShowDialog() == DialogResult.OK) {
			font = fd.Font;
			text = font.Name;
			Refresh();
		}
	}

	protected override void OnPaint(PaintEventArgs e) {
		e.Graphics.DrawString(text, font, SystemBrushes.WindowText, 20, 60);
	}

	static void Main() {
		Application.Run(new FontDialogDemo());
	}
}