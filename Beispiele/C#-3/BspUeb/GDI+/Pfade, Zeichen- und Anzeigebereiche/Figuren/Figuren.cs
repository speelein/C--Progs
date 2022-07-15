using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class Figuren : Form {
	Pen pen = new Pen(Color.Black, 5);
	GraphicsPath path = new GraphicsPath();

	Figuren() {
		Text = "Figuren";
		ClientSize = new Size(400, 250);
		path.AddBezier(100, 150, 150, 250, 400, 200, 250, 50);
		path.CloseFigure();
		path.AddEllipse(250, 100, 15, 15);
		path.AddLine(200, 200, 180, 150);
	}

	protected override void OnPaint(PaintEventArgs e) {
		e.Graphics.FillPath(Brushes.BurlyWood, path);
		e.Graphics.DrawPath(pen, path);
	}

	[STAThread]
	static void Main() {
		Application.Run(new Figuren());
	}
}
