using System;
using System.Windows.Forms;
using System.Drawing;

class Einpassen : Form {
	Bitmap image;
	RectangleF ra;

	Einpassen() {
		Text = "Einpassen";
		ClientSize = new Size(680, 280);
		image = new Bitmap("EmmaBodo.jpg");
		//image = new Bitmap("land.jpg");

		// Spiegeln des Bildes
		//image.RotateFlip(RotateFlipType.RotateNoneFlipX);

		// Graphics-Zeichenmethoden auf ein Bitmap-Objekt anwenden
		Pen pen = new Pen(Color.Red, 20);
		Graphics g = Graphics.FromImage(image);
		g.DrawRectangle(pen, 1450, 50, 700, 650);

		// Einpassen mit dem korrekten Seitenverhältnis
		int bmh = image.Width;
		int bmv = image.Height;
		float faktor = Math.Min(((float)ClientSize.Width) / bmh,
			                    ((float)ClientSize.Height) / bmv);
		if (faktor < 1.0)
			ra = new RectangleF(0, 0, faktor*bmh, faktor*bmv);
		else
			ra = new RectangleF(0, 0, bmh, bmv);
	}

	protected override void OnPaint(PaintEventArgs e) {
		e.Graphics.DrawImage(image, ra);
	}

	[STAThread]
	static void Main() {
		Application.Run(new Einpassen());
	}
}
