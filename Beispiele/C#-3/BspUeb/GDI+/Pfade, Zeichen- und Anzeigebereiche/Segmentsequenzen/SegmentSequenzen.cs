using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System;

public class Segmentsequenzen : Form {
	Pen stift = new Pen(Color.Black, 10);
	GraphicsPath gp = new GraphicsPath();

	Segmentsequenzen() {
		Text = "Segmentsequenzen";
		//gp.AddLine(50, 50, 200, 50);
		//gp.AddLine(200, 50, 200, 200);
		//gp.AddLine(200, 200, 100, 200);

		//gp.AddLine(200, 50, 200, 200);
		//gp.AddLine(200, 200, 100, 200);
		//gp.AddLine(50, 50, 200, 50);
		//gp.CloseFigure();

		gp.AddLine(50, 50, 200, 50);
		gp.AddLine(200, 200, 100, 200);
		gp.CloseFigure();
	}

	protected override void OnPaint(PaintEventArgs e) {
		//g.DrawString("1", Font, Brushes.Black, 120, 30);
		//g.DrawString("2", Font, Brushes.Black, 210, 115);
		//g.DrawString("3", Font, Brushes.Black, 145, 210);

		//g.DrawString("1", Font, Brushes.Black, 210, 115);
		//g.DrawString("2", Font, Brushes.Black, 145, 210);
		//g.DrawString("3", Font, Brushes.Black, 120, 30);

		e.Graphics.DrawString("1", Font, Brushes.Black, 120, 30);
		e.Graphics.DrawString("2", Font, Brushes.Black, 145, 210);

		e.Graphics.DrawPath(stift, gp);
	}

	[STAThread]
	static void Main() {
		Application.Run(new Segmentsequenzen());
	}
}
