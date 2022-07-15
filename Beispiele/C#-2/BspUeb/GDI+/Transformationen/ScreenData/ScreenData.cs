using System;
using System.Windows.Forms;
using System.Drawing;

class ScreenData : Form {
	public ScreenData() {
		Text = "ScreenData";
		BackColor = Color.White;
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		g.DrawString("Pixel pro Zeile:\t" + Screen.PrimaryScreen.Bounds.Width.ToString() +
									"\nPixel pro Spalte:\t" + Screen.PrimaryScreen.Bounds.Height + 
									"\nHoriz. Aufl.:\t" + g.DpiX.ToString() +
								 "\nVertik. Aufl.:\t" + g.DpiY.ToString(),
								 Font, SystemBrushes.WindowText, 10, 10);
	}

	static void Main() {
		Application.Run(new ScreenData());
	}
}