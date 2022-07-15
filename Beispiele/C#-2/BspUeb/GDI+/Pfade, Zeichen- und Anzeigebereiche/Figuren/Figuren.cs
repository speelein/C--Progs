using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class Figuren : Form {

	public Figuren() {
		Text = "Figuren";
		ClientSize = new Size(400, 250);
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		Pen pen = new Pen(Color.Black, 15);
		GraphicsPath path = new GraphicsPath();
		path.AddBezier(100, 150, 150, 250, 400, 200, 250, 50);
		path.CloseFigure();
		path.AddEllipse(250, 100, 15, 15);
		path.AddLine(200, 200, 180, 150);
		g.FillPath(Brushes.BurlyWood, path);
		g.DrawPath(pen, path);
	}

	static void Main() {
		Application.Run(new Figuren());
	}
}
