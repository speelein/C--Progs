using System;
using System.Windows.Forms;
using System.Drawing;

class ResizeRedrawDemo : Form {
	ResizeRedrawDemo() {
		Text = "Resize-Demo";
		Height = 200; Width = 300;
		ResizeRedraw = true;
	}

	protected override void OnPaint(PaintEventArgs e) {
		e.Graphics.DrawLine(Pens.Black, 0, 0, ClientSize.Width, ClientSize.Height);
	}

	[STAThread]
	static void Main() {
		Application.Run(new ResizeRedrawDemo());
	}
}