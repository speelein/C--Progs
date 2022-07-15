using System;
using System.Windows.Forms;
using System.Drawing;

class Kollision : Form {
	public Kollision() {
		Text = "Kollision";
		Size = new Size(270, 200);
		ResizeRedraw = true;
		StatusBar sb = new StatusBar();
		sb.Parent = this;
		sb.Text = "Eine Statuszeile belegt Platz im Klientenbereich!";
	}
	protected override void OnPaint(PaintEventArgs e) {
		Pen stift = new Pen(Color.Black, 5);
		e.Graphics.DrawLine(stift, 0, 0, ClientSize.Width, ClientSize.Height);
	}
	static void Main() {
		Application.Run(new Kollision());
	}
}