using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class BrushDemo : Form {
	BrushDemo() {
		Text = "Brush-Demo";
		Width = 290; Height = 150;
	}

	protected override void OnPaint(PaintEventArgs e) {
		Rectangle ra = new Rectangle(40, 10, 200, 100);
		Graphics g = e.Graphics;

		// ****************************  SolidBrush  ****************************
		g.DrawLine(new Pen(Color.Blue, 10), 20, 75, 260, 75);
		g.FillEllipse(new SolidBrush(Color.FromArgb(50, 0, 255, 0)), ra);

		// ****************************HatchBrush * ***************************
		//g.FillEllipse(new HatchBrush(HatchStyle.DiagonalCross,
		//               Color.Blue, Color.Yellow), ra);

		// ****************************TextureBrush * ***************************
		//g.FillEllipse(new TextureBrush(new Bitmap("textur.bmp")), ra);
		//g.FillEllipse(new TextureBrush(new Bitmap("land.jpg")), ra);
		//BackColor = Color.Red;
		//g.DrawString("Schreiben mit Textur", new Font("Arial", 20, FontStyle.Bold),
		//              new TextureBrush(new Bitmap("water.bmp")), 3, 40);

		// ****************************LinearGradientBrush * ********************
		//g.FillEllipse(new LinearGradientBrush(new Point(0, 0), new Point(Width, Height),
		//                Color.White, Color.Red), ra);

		////****************************Brushes * ********************************
		//Text = "Brushes-Demo";
		//g.FillEllipse(Brushes.Blue, ra);


		////****************************SystemBrushes * **************************
		//Text = "SystemBrushes-Demo";
		//g.FillEllipse(SystemBrushes.Desktop, ra);
	}

	[STAThread]
	static void Main() {
		Application.Run(new BrushDemo());
	}
}
