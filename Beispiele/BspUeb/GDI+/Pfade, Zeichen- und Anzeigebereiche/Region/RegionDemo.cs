using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class RegionDemo : Form {
	Point lastMousePos = new Point();
	Bitmap image;
	GraphicsPath gp;
	Pen stift;
	int shiftX, shiftY;

	public RegionDemo() {
		Text = "Region-Demo";
		Size = new Size(500, 400);
		Point ul = new Point(150, 350);
		Point ur = new Point(350, 350);
		Point p0 = new Point(200, 200);
		Point p1 = new Point(70, 10);
		Point p2 = new Point(430, 10);
		Point p3 = new Point(300, 200);
		Point[] lz = new Point[] { p3, ur, ul, p0 };
		gp = new GraphicsPath();
		gp.AddLines(lz);
		gp.AddBezier(p0, p1, p2, p3);
		gp.CloseFigure();
		Region = new Region(gp);
		image = new Bitmap("land.bmp");
		Button cbClose = new Button();
		cbClose.Top = 280;
		cbClose.Left = 210;
		cbClose.Text = "Beenden";
		cbClose.Parent = this;
		cbClose.Click += new EventHandler(ButtonOnClick);
		stift = new Pen(Color.CadetBlue, 10);
		shiftX = -((Width - ClientSize.Width)/2);
		shiftY = -(Height - ClientSize.Height + shiftX);
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		g.TranslateTransform(shiftX, shiftY);
		g.DrawImage(image, new RectangleF(120, 10,
												image.Width, 1.5f * image.Height));
		g.DrawPath(stift, gp);
	}

	protected override void OnMouseDown(MouseEventArgs e) {
		lastMousePos = PointToScreen(new Point(e.X, e.Y));
	}

	protected override void OnMouseMove(MouseEventArgs e) {
		if (e.Button == MouseButtons.Left) {
			Point actMousePos = PointToScreen(new Point(e.X, e.Y));
			int dx = actMousePos.X - lastMousePos.X;
			int dy = actMousePos.Y - lastMousePos.Y;
			if (Math.Abs(dx) > 0 || Math.Abs(dy) > 0) {
				Left += dx;
				Top += dy;
				lastMousePos = actMousePos;
			}
		}
	}

	void ButtonOnClick(object sender, EventArgs e) {
		Close();
	}

	static void Main() {
		Application.Run(new RegionDemo());
	}
}
