using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System;

public class Clipping : Form {

	public Clipping() {
		Text = "Clipping";
		ClientSize = new Size(500, 400);
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		Pen stift = new Pen(Color.Black, 10);

		Point ul = new Point(150, 350);
		Point ur = new Point(350, 350);
		Point p0 = new Point(200, 200);
		Point p1 = new Point(70, 10);
		Point p2 = new Point(430, 10);
		Point p3 = new Point(300, 200);
		Point[] lz = new Point[] {p3, ur, ul, p0};

		GraphicsPath gp = new GraphicsPath();
		gp.AddLines(lz);
		gp.AddBezier(p0, p1, p2, p3);
		gp.CloseFigure();
		g.DrawPath(stift, gp);

		//g.SetClip(gp);
		//g.Clear(Color.White);
		//Pen rotstift = new Pen(Color.Red, 10);
		//g.DrawLine(rotstift, 100, 10, 400, 400);

		Bitmap image = new Bitmap("land.bmp");
		g.SetClip(gp);
		g.DrawImage(image, new RectangleF(100, 50, image.Width, 1.5f * image.Height));

	}

	static void Main() {
		Application.Run(new Clipping());
	}
}