using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

class InvalidateRectangle : Form {
	List<Point> punkte = new List<Point>();

	InvalidateRectangle() {
		Text = "InvalidateUpdateRefresh";
		MouseDown += new MouseEventHandler(FormOnMouseDown);
		Paint += new PaintEventHandler(FormOnPaint);
	}

	void FormOnPaint(object sender, PaintEventArgs e) {
		foreach (Point p in punkte)
			e.Graphics.FillEllipse(Brushes.Blue, p.X, p.Y, 20, 20);
	}

	void FormOnMouseDown(object sender, MouseEventArgs e) {
		Point punkt = new Point(e.X - 10, e.Y - 10);
		punkte.Add(punkt);
		Invalidate(new Rectangle(punkt, new Size(20, 20)));
	}

	[STAThread]
	static void Main() {
		Application.Run(new InvalidateRectangle());
	}
}