using System;
using System.Windows.Forms;
using System.Drawing;

class PageUnitScale : Form {
	public PageUnitScale() {
		Text = "PageUnitScale";
		BackColor = Color.White;
		ClientSize = new Size(500, 150);
	}

	//protected override void OnPaint(PaintEventArgs e) {
	//  Graphics g = e.Graphics;
	//  g.DrawString("PageUnit:\t\t" + g.PageUnit.ToString() +
	//               "\nPageScale:\t\t" + g.PageScale.ToString() +
	//               "\nClientSize:\t\t" + ClientSize.ToString(),
	//               new Font("Arial", 10), SystemBrushes.WindowText, 50, 10);
	//  g.PageUnit = GraphicsUnit.Millimeter;
	//  g.PageScale = 0.1f;
	//  g.DrawString("PageUnit:\t\t" + g.PageUnit.ToString() +
	//               "\nPageScale:\t\t" + g.PageScale.ToString() +
	//               "\nClientSize:\t\t" + ClientSize.ToString(),
	//               new Font("Arial", 10), SystemBrushes.WindowText, 50, 200);
	//}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		g.DrawString("PageUnit:\t\t" + g.PageUnit.ToString() +
								 "\nPageScale:\t\t" + g.PageScale.ToString() +
								 "\nVisibleClipBounds:\t" + g.VisibleClipBounds.ToString(),
								 new Font("Arial", 10), SystemBrushes.WindowText, 50, 10);

		g.PageUnit = GraphicsUnit.Millimeter;
		g.PageScale = 0.1f;
		//g.DrawString("PageUnit:\t\t" + g.PageUnit.ToString() +
		//             "\nPageScale:\t\t" + g.PageScale.ToString() +
		//             "\nVisibleClipBounds:\t" + g.VisibleClipBounds.ToString(),
		//             new Font("Arial", 10), SystemBrushes.WindowText, 50, 200);
		g.DrawString("Breite in mm/10:\t" +
							 (ClientSize.Width / g.DpiX * 2.54 * 100).ToString() +
							 "\nHöhe in mm/10:\t" +
							 (ClientSize.Height / g.DpiX * 2.54 * 100).ToString(),
							 new Font("Arial", 10), SystemBrushes.WindowText, 50, 200);
	}
	
	static void Main() {
		Application.Run(new PageUnitScale());
	}
}