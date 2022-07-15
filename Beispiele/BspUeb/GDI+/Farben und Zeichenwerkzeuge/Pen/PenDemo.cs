using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class PenDemo : Form {
	public PenDemo() {
		Text = "Pen-Demo";
		Width = 250; Height = 250;
	}

	protected override void OnPaint(PaintEventArgs e) {
		Pen stift = new Pen(Color.Black, 10);
		stift.EndCap = LineCap.ArrowAnchor;
		stift.DashStyle = DashStyle.Dash;
		e.Graphics.DrawLine(stift, 50, 50, 200, 100);
		stift.DashCap = DashCap.Round;
		stift.StartCap = LineCap.Round;
		e.Graphics.DrawLine(stift, 50, 100, 200, 150);
		//		e.Graphics.DrawLine(SystemPens.ControlDark, 50,50,200,100);
	}

	static void Main() {
		Application.Run(new PenDemo());
	}
}
