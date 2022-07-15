using System;
using System.Windows.Forms;
using System.Drawing;

class TranslateTransformDemo : Form {
	public TranslateTransformDemo() {
		Text = "TranslateTransform";
		ClientSize = new Size(250, 250);
	}

protected override void OnPaint(PaintEventArgs e) {
	Graphics g = e.Graphics;
	Pen p = new Pen(Color.Black, 2);
	for (int i = 0; i < 6; i++) {
		g.DrawEllipse(p, 0, 0, 30, 30);
		g.TranslateTransform(40, 40);
	}
	p.Dispose();
}

	static void Main() {
		Application.Run(new TranslateTransformDemo());
	}
}
