using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class BrushDemo : Form {
	public BrushDemo() {
		Text = "Brush-Demo";
		Width = 290; Height = 150;
	}

	protected override void OnPaint(PaintEventArgs e) {
		Rectangle ra = new Rectangle(40, 10, 200, 100);
		Graphics gc = e.Graphics;

		// ****************************  SolidBrush  ****************************
		gc.DrawLine(new Pen(Color.Blue, 10), 20, 75, 260, 75);
		gc.FillEllipse(new SolidBrush(Color.FromArgb(50, 0, 255, 0)), ra);

		// ****************************  HatchBrush  ****************************
		//gc.FillEllipse(new HatchBrush(HatchStyle.DiagonalCross,
		//               Color.Blue, Color.Yellow), ra);

		// ****************************  TextureBrush  ****************************
		//gc.FillEllipse(new TextureBrush(new Bitmap("textur.bmp")), ra);
		//gc.FillEllipse(new TextureBrush(new Bitmap("land.bmp")), ra);
		//BackColor = Color.Red;
		//gc.DrawString("Schreiben mit Textur",	new Font("Arial", 20, FontStyle.Bold),
		//              new TextureBrush(new Bitmap("water.bmp")),3, 40);
		// ****************************  LinearGradientBrush  *********************
		//gc.FillEllipse(new LinearGradientBrush(new Point(0, 0), new Point(Width, Height),
		//                Color.White, Color.Red), ra);

		// ****************************  Brushes  *********************************
		//Text = "Brushes-Demo";
		//gc.FillEllipse(Brushes.Blue, ra);


		// ****************************  SystemBrushes  ***************************
		//Text = "SystemBrushes-Demo";
		//gc.FillEllipse(SystemBrushes.Desktop, ra);
	}

	static void Main() {
		Application.Run(new BrushDemo());
	}
}
