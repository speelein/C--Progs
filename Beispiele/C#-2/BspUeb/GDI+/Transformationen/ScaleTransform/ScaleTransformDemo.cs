using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class ScaleTransformDemo : Form {
	public ScaleTransformDemo() {
		Text = "ScaleTransform";
		ClientSize = new Size(350, 350);
		this.ResizeRedraw = true;
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		Pen pen = Pens.Black;
		g.DrawEllipse(pen, 20, 20, 300, 300);
		g.ScaleTransform(1, 0.5f);
		g.DrawEllipse(pen, 20, 20, 300, 300);
	}

	static void Main() {
		Application.Run(new ScaleTransformDemo());
	}
}
