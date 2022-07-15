using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

class Doppelpufferung : Form {
	List<Point> punkte = new List<Point>();

	Doppelpufferung() {
		Text = "InvalidateUpdateRefresh";
		MouseDown += new MouseEventHandler(FormOnMouseDown);
		Paint += new PaintEventHandler(FormOnPaint);
		DoubleBuffered = true;
	}

	void FormOnPaint(object sender, PaintEventArgs e) {
		foreach (Point p in punkte)
			e.Graphics.FillEllipse(Brushes.Blue, p.X, p.Y, 20, 20);
	}

	void FormOnMouseDown(object sender, MouseEventArgs e) {
		punkte.Add(new Point(e.X - 10, e.Y - 10));
		Invalidate();
	}

	[STAThread]
	static void Main() {
		Application.Run(new Doppelpufferung());
	}
}