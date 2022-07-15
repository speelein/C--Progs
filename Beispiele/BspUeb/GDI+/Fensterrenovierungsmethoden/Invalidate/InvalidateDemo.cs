using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

class InvalidateDemo : Form {
	ArrayList punkte = new ArrayList();

	public InvalidateDemo() {
		Text = "Invalidate-Demo";
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

	static void Main() {
		Application.Run(new InvalidateDemo());
	}
}