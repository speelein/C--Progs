using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System;

class Clipping : Form {
	Pen stift = new Pen(Color.DarkGray, 10);
	GraphicsPath gp = new GraphicsPath();
	Bitmap image = new Bitmap("land.jpg");

	Clipping() {
		Text = "Clipping";
		ClientSize = new Size(500, 400);
		Point ul = new Point(150, 350);
		Point ur = new Point(350, 350);
		Point p0 = new Point(200, 200);
		Point p1 = new Point(70, 10);
		Point p2 = new Point(430, 10);
		Point p3 = new Point(300, 200);
		Point[] lz = new Point[] { p0, ul, ur, p3 };
		gp.AddLines(lz);
		gp.AddBezier(p3, p2, p1, p0);
		gp.CloseFigure();
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		g.SetClip(gp);
		//g.Clear(Color.White);
		//g.DrawPath(stift, gp);
		g.DrawImage(image, new RectangleF(100, 50, image.Width, 1.5f * image.Height));
	}

	[STAThread]
	static void Main() {
		Application.Run(new Clipping());
	}
}