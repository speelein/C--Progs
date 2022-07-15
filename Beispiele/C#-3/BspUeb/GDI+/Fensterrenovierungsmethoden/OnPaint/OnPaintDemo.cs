using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

class OnPaintDemo : Form {
	List<Point> punkte = new List<Point>();

	OnPaintDemo() {
		Text = "OnPaint-Demo";
		MouseDown += new MouseEventHandler(FormOnMouseDown);
	}

	protected override void OnPaint(PaintEventArgs e) {
		foreach (Point p in punkte)
			e.Graphics.FillEllipse(Brushes.Blue, p.X, p.Y, 20, 20);
	}

	void FormOnMouseDown(object sender, MouseEventArgs e) {
		Graphics g = this.CreateGraphics();
		g.FillEllipse(Brushes.Blue, e.X - 10, e.Y - 10, 20, 20);
		g.Dispose();
		punkte.Add(new Point(e.X - 10, e.Y - 10));
	}

	[STAThread]
	static void Main() {
		Application.Run(new OnPaintDemo());
	}
}
