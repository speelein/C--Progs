using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class RotateTransformDemo : Form {
	public RotateTransformDemo() {
		Text = "RotateTransform";
		ClientSize = new Size(350, 250);
		this.ResizeRedraw = true;
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		g.PageUnit = GraphicsUnit.Millimeter;
		g.TranslateTransform(30, 10); 
		g.DrawRectangle(Pens.Blue, 0, 0, 50, 20);
		g.RotateTransform(90);
		g.DrawRectangle(Pens.Red, 0, 0, 50, 20);
	}

	static void Main() {
		Application.Run(new RotateTransformDemo());
	}
}
