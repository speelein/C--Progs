using System;
using System.Windows.Forms;
using System.Drawing;

class FontDialogDemo : Form {
	Label lbProbe;
	FontDialog fd = new FontDialog();

	FontDialogDemo() {
		Text = "FontDialog-Demo";
		Size = new Size(250, 150);
		MinimumSize = new Size(250, 150);
		BackColor = SystemColors.Window;

		lbProbe = new Label();
		lbProbe.Font = new Font("Arial", 24, FontStyle.Bold);
		lbProbe.Text = lbProbe.Font.Name;
		lbProbe.Left = 20; lbProbe.Top = 60;
		lbProbe.AutoSize = true;
		Controls.Add(lbProbe);

		Button cbFont = new Button();
		cbFont.Text = "Schriftart wählen";
		cbFont.BackColor = SystemColors.Control;
		cbFont.Top = 20; cbFont.Left = 20;
		cbFont.Width = 200;
		cbFont.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		Controls.Add(cbFont);
		cbFont.Click += new EventHandler(ButtonOnClick);
	}

	protected void ButtonOnClick(object sender, EventArgs e) {
		if (fd.ShowDialog() == DialogResult.OK) {
			//MessageBox.Show(fd.Font.SizeInPoints.ToString());
			Font oldFont = lbProbe.Font;
			lbProbe.Font = new Font(fd.Font.FontFamily,
				(float) Math.Round(fd.Font.SizeInPoints), fd.Font.Style);
			oldFont.Dispose();
			lbProbe.Text = fd.Font.Name;
		}
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new FontDialogDemo());
	}
}