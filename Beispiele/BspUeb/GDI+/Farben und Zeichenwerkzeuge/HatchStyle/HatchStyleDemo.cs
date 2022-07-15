using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class HatchStyleDemo : Form {
	HatchStyle[] hs = (HatchStyle[]) Enum.GetValues(typeof(HatchStyle));
	String[] hsn = (String[])Enum.GetNames(typeof(HatchStyle));
	int breite = 100, hoehe = 100, abstand = 10;

	public HatchStyleDemo() {
		Text = "HatchStyle-Demo";
		this.ClientSize = new Size((int)(2.5*breite), 2*hoehe + 3*abstand);
		AutoScroll = true;
		Panel pan = new Panel();
		pan.Height = hs.Length * hoehe + abstand;
		pan.Paint += new PaintEventHandler(PanelOnPaint);
		pan.Parent = this;
	}

	void PanelOnPaint(object sender, PaintEventArgs e) {
		int olY = -hoehe;
		Graphics gc = e.Graphics;
		for (int i = 0; i < hs.Length; i++) {
			HatchBrush hb = new HatchBrush(hs[i], Color.Blue, Color.Yellow);
			olY += hoehe + abstand;
			gc.FillRectangle(hb, new Rectangle(abstand, olY, breite, hoehe));
			gc.DrawString(hsn[i], Font, SystemBrushes.WindowText, breite+2*abstand, olY + hoehe/2);
			hb.Dispose();
		}
	}

	static void Main() {
		Application.Run(new HatchStyleDemo());
	}
}