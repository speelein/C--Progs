using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

class OnMethodenDemo : Form {
	ArrayList punkte = new ArrayList();

	public OnMethodenDemo() {
		Text = "OnMethoden-Demo";
	}

	protected override void OnPaint(PaintEventArgs e) {
		//base.OnPaint(e);
		foreach (Point p in punkte)
			e.Graphics.FillEllipse(Brushes.Blue, p.X, p.Y, 20, 20);
	}

	protected override void OnMouseDown(MouseEventArgs e) {
		Graphics g = this.CreateGraphics();
		g.FillEllipse(Brushes.Blue, e.X - 10, e.Y - 10, 20, 20);
		punkte.Add(new Point(e.X - 10, e.Y - 10));
		g.Dispose();
	}

	static void Main() {
		Application.Run(new OnMethodenDemo());
	}
}