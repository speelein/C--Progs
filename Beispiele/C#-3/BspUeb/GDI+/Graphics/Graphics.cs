using System;
using System.Windows.Forms;
using System.Drawing;

class GraphicsDemo : Form {
	GraphicsDemo() {
		Text = "Graphics-Demo";
		MouseDown += new MouseEventHandler(FormOnMouseDown);
	}

	void FormOnMouseDown(object sender, MouseEventArgs e) {
		Graphics g = this.CreateGraphics();
		g.FillEllipse(Brushes.Blue, e.X - 10, e.Y - 10, 20, 20);
		g.Dispose();
	}

	[STAThread]
	static void Main() {
		Application.Run(new GraphicsDemo());
	}
}