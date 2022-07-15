using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System;

public class Segmentsequenzen : Form {

	public Segmentsequenzen() {
		Text = "Segmentsequenzen";
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		Pen stift = new Pen(Color.Black, 10);

		GraphicsPath gp = new GraphicsPath();

		gp.AddLine(50, 50, 200, 50);
		gp.AddLine(200, 50, 200, 200);
		gp.AddLine(200, 200, 100, 200);

		//gp.AddLine(200, 50, 200, 200);
		//gp.AddLine(200, 200, 100, 200);
		//gp.AddLine(50, 50, 200, 50);
		//gp.CloseFigure();

		g.DrawPath(stift, gp);
	}

	static void Main() {
		Application.Run(new Segmentsequenzen());
	}
}
