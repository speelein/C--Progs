using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class RotateTransformDemo : Form {
	RotateTransformDemo() {
		Text = "RotateTransform";
		ClientSize = new Size(400, 250);
		this.ResizeRedraw = true;
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		g.PageUnit = GraphicsUnit.Millimeter;
		g.TranslateTransform(50, 15); 
		g.DrawRectangle(Pens.Blue, 0, 0, 50, 20);
		g.RotateTransform(120);
		g.DrawRectangle(Pens.Red, 0, 0, 50, 20);
	}

	[STAThread]
	static void Main() {
		Application.Run(new RotateTransformDemo());
	}
}
