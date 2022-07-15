using System;
using System.Windows.Forms;
using System.Drawing;

class PageUnitScale : Form {
	PageUnitScale() {
		Text = "PageUnitScale";
		BackColor = Color.White;
		ClientSize = new Size(500, 150);
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		g.DrawString("PageUnit:\t\t" + g.PageUnit.ToString() +
					 "\nPageScale:\t\t" + g.PageScale.ToString() +
					 "\nClientSize:\t\t" + ClientSize.ToString(),
					 new Font("Arial", 10), SystemBrushes.WindowText, 50, 10);
		g.PageUnit = GraphicsUnit.Millimeter;
		g.PageScale = 0.1f;
		g.DrawString("PageUnit:\t\t" + g.PageUnit.ToString() +
					 "\nPageScale:\t\t" + g.PageScale.ToString() +
					 "\nClientSize:\t\t" + ClientSize.ToString(),
					 new Font("Arial", 10), SystemBrushes.WindowText, 50, 200);
	}

	// Linie mit 5 cm Länge zeichnen
	//protected override void OnPaint(PaintEventArgs e) {
	//    Graphics g = e.Graphics;
	//    // Noch gilt: Seitenkoordinaten = Gerätekoordinaten
	//    g.DrawLine(Pens.Black, 38, 38, 227, 38);

	//    // Definition der Seitentransformation
	//    g.PageUnit = GraphicsUnit.Millimeter;
	//    g.PageScale = 0.1f;

	//    // Aus diesen Seitenkoordinaten werden die Gerätekoordinaten (38, 38, 227, 38)
	//    g.DrawLine(Pens.Black, 100, 100, 600, 100);
	//}

	[STAThread]
	static void Main() {
		Application.Run(new PageUnitScale());
	}
}