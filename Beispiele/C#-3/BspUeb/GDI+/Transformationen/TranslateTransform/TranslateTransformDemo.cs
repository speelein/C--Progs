using System;
using System.Windows.Forms;
using System.Drawing;

class TranslateTransformDemo : Form {
	TranslateTransformDemo() {
		Text = "TranslateTransform";
		ClientSize = new Size(250, 250);
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		for (int i = 0; i < 6; i++) {
			g.DrawEllipse(Pens.Black, 0, 0, 30, 30);
			g.TranslateTransform(40, 40);
		}
	}

	[STAThread]
	static void Main() {
		Application.Run(new TranslateTransformDemo());
	}
}
