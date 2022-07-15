using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class PenDemo : Form {
	Pen dick = new Pen(Color.Yellow, 20);

	PenDemo() {
		Text = "Pen-Alignment";
		Size = new Size(350, 240);
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		g.DrawRectangle(dick, 50, 50, 100, 100);
		g.DrawRectangle(Pens.Black, 50, 50, 100, 100);
		dick.Alignment = PenAlignment.Inset;
		g.DrawRectangle(dick, 200, 50, 100, 100);
		g.DrawRectangle(Pens.Black, 200, 50, 100, 100);
		g.DrawLine(dick, 200, 180, 300, 180);
		g.DrawLine(Pens.Black, 200, 180, 300, 180);
		dick.Alignment = PenAlignment.Center;
	}

	[STAThread]
	static void Main() {
		Application.Run(new PenDemo());
	}
}
