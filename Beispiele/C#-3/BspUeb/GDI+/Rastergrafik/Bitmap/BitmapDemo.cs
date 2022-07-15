using System;
using System.Windows.Forms;
using System.Drawing;

class BitmapDemo : Form {
	Bitmap image;
	RectangleF ra;

	BitmapDemo() {
		Text = "Bitmap";
		ClientSize = new Size(680, 280);
		image = new Bitmap("land.jpg");
		ra = new RectangleF(280, 10, 1.5f * image.Width, image.Height);
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		g.DrawImage(image, 10, 10);
		g.DrawImage(image, ra);
	}

	[STAThread]
	static void Main() {
		Application.Run(new BitmapDemo());
	}
}
