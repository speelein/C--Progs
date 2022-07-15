using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

class InvalidateUpdateRefresh : Form {
	List<Point> punkte = new List<Point>();

	InvalidateUpdateRefresh() {
		Text = "InvalidateUpdateRefresh";
		MouseDown += new MouseEventHandler(FormOnMouseDown);
		Paint += new PaintEventHandler(FormOnPaint);
	}

	void FormOnPaint(object sender, PaintEventArgs e) {
		foreach (Point p in punkte)
			e.Graphics.FillEllipse(Brushes.Blue, p.X, p.Y, 20, 20);
	}

	void FormOnMouseDown(object sender, MouseEventArgs e) {
		punkte.Add(new Point(e.X - 10, e.Y - 10));
		//Invalidate();
		//Update();
		Refresh();
	}

	[STAThread]
	static void Main() {
		Application.Run(new InvalidateUpdateRefresh());
	}
}