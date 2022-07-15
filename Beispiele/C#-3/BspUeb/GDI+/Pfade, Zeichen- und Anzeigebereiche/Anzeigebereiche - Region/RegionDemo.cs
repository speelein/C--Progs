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

	RegionDemo() {
		Size = new Size(500, 400);
		Point ul = new Point(170, 300);
		Point ur = new Point(300, 300);
		Point p0 = new Point(190, 200);
		Point p1 = new Point(70, 10);
		Point p2 = new Point(400, 10);
		Point p3 = new Point(280, 200);
		Point[] lz = new Point[] {p0, ul, ur, p3};
		gp = new GraphicsPath();
		gp.AddLines(lz);
		gp.AddBezier(p3, p2, p1, p0);
		gp.CloseFigure();
		Region = new Region(gp);
		image = new Bitmap("land.jpg");
		Button cbClose = new Button();
		cbClose.Top = 230;
		cbClose.Left = 194;
		cbClose.Text = "Beenden";
		cbClose.Parent = this;
		cbClose.Click += new EventHandler(ButtonOnClick);
		stift = new Pen(SystemColors.ButtonFace, 10);
		shiftX = -((Width - ClientSize.Width)/2);
		shiftY = -(Height - ClientSize.Height + shiftX);
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		g.SmoothingMode = SmoothingMode.HighQuality;
		g.TranslateTransform(shiftX, shiftY);
		g.DrawImage(image, new RectangleF(120, 60, image.Width, image.Height));
		g.DrawPath(stift, gp);
	}

	protected override void OnMouseDown(MouseEventArgs e) {
		lastMousePos = PointToScreen(new Point(e.X, e.Y));
	}

	protected override void OnMouseMove(MouseEventArgs e) {
		if (e.Button == MouseButtons.Left) {
			Point actMousePos = PointToScreen(new Point(e.X, e.Y));
			Left += actMousePos.X - lastMousePos.X;
			Top += actMousePos.Y - lastMousePos.Y;
			lastMousePos = actMousePos;
		}
	}

	void ButtonOnClick(object sender, EventArgs e) {
		Close();
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new RegionDemo());
	}
}
