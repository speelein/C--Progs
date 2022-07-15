using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class PenDemo : Form {

	public PenDemo() {
		Text = "Pen-Alignment";
		Size = new Size(350, 240);
	}

	protected override void OnPaint(PaintEventArgs e) {
		Pen duenn = Pens.Black;
		Pen dick = new Pen(Color.Yellow, 20);
		e.Graphics.DrawRectangle(dick, 50, 50, 100, 100);
		e.Graphics.DrawRectangle(duenn, 50, 50, 100, 100);
		dick.Alignment = PenAlignment.Inset;
		e.Graphics.DrawRectangle(dick, 200, 50, 100, 100);
		e.Graphics.DrawRectangle(duenn, 200, 50, 100, 100);
	}

	static void Main() {
		Application.Run(new PenDemo());
	}
}
