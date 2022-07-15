using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class BitmapDemo : Form {

	public BitmapDemo() {
		Text = "Bitmap";
		ClientSize = new Size(680, 280);
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		Bitmap image = new Bitmap("land.bmp");
		g.DrawImage(image, 10, 10);
		RectangleF neueForm = new RectangleF(280, 10, 1.5f * image.Width, image.Height);
		g.DrawImage(image, neueForm);
	}

	static void Main() {
		Application.Run(new BitmapDemo());
	}
}
