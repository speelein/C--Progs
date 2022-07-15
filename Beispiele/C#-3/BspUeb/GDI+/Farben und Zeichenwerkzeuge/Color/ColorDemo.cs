using System;
using System.Windows.Forms;
using System.Drawing;

class ColorDemo : Form {
	Pen penBlue = new Pen(Color.Blue, 5);
	Pen penRed = new Pen(Color.FromArgb(150, 255, 0, 0), 5);
	Color uc;
	bool puc = false;
	ColorDialog cd = new ColorDialog();

	ColorDemo() {
		Text = "Color-Demo";
		Size = new Size(300, 210);
		Button cbColor = new Button();
		cbColor.Text = "Farbwahl";
		cbColor.Top = 70;
		cbColor.Left = 200;
		Controls.Add(cbColor);
		cbColor.Click += new EventHandler(FarbwahlOnClick);
	}

	protected void FarbwahlOnClick(object sender, EventArgs e) {
		if (cd.ShowDialog() == DialogResult.OK) {
			uc = cd.Color;
			puc = true;
			Refresh();
		}
	}

	protected override void OnPaint(PaintEventArgs e) {
		e.Graphics.DrawEllipse(penBlue, 50, 10, 100, 75);
		e.Graphics.DrawEllipse(penRed, 50, 50, 100, 75);
		if (puc) {
			Pen penUs = new Pen(uc, 5);
			e.Graphics.DrawEllipse(penUs, 50, 90, 100, 75);
			penUs.Dispose();
		}
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new ColorDemo());
	}
}