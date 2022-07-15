using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class PenDemo : Form {
	Pen stift = new Pen(Color.Firebrick, 10);

	PenDemo() {
		Text = "Pen-Demo";
		Width = 250; Height = 250;
	}

	protected override void OnPaint(PaintEventArgs e) {
		stift.DashStyle = DashStyle.Dash;
		stift.EndCap = LineCap.ArrowAnchor;
		e.Graphics.DrawLine(stift, 50, 50, 200, 100);
		stift.DashCap = DashCap.Round;
		stift.StartCap = LineCap.Round;
		e.Graphics.DrawLine(stift, 50, 100, 200, 150);
	}

	[STAThread]
	static void Main() {
		Application.Run(new PenDemo());
	}
}
