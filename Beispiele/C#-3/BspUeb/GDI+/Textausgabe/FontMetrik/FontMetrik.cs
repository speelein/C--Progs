using System.Windows.Forms;
using System.Drawing;
using System;

public class FontMetrik : Form {
	FontFamily fontFam;
	Brush brush = SystemBrushes.WindowText;

	FontMetrik() {
		Text = "FontMetrik";
		fontFam = new FontFamily("Times New Roman");
		Font = new Font(fontFam, 10);
		ClientSize = new Size(380, 165);
		BackColor = SystemColors.Window;
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		int i = 0, vs = Font.Height;

		g.DrawString("DpiY (des Graphics-Objekts) = " + g.DpiY.ToString(), Font, brush, 0, 0);

		g.DrawString("Eigenschaften der Schriftart Times New Roman:", Font, brush, 0, ++i * vs);
		g.DrawString("Entwurfseinheiten insgesamt = " + fontFam.GetEmHeight(FontStyle.Regular).ToString(), Font, brush, 10, ++i * vs);
		g.DrawString("Entwurfseinheiten über der Grundlinie = " + fontFam.GetCellAscent(FontStyle.Regular).ToString(), Font, brush, 10, ++i * vs);
		g.DrawString("Entwurfseinheiten unter der Grundlinie = " + fontFam.GetCellDescent(FontStyle.Regular).ToString(), Font, brush, 10, ++i * vs);
		g.DrawString("Empfohlener Zeilenabstand = " + fontFam.GetLineSpacing(FontStyle.Regular).ToString(), Font, brush, 10, ++i * vs);

		g.DrawString("Font.SizeInPoints = " + Font.SizeInPoints.ToString(), Font, brush, 0, ++i * vs);
		g.DrawString("Font.GetHeight() = " + Font.GetHeight(g).ToString(), Font, brush, 0, ++i * vs);
		g.DrawString("Font.Height = " + Font.Height.ToString(), Font, brush, 0, ++i * vs);
		g.DrawString("MeasureString(\"A\", Font) = " + g.MeasureString("A", Font).ToString(), Font, brush, 0, ++i * vs);
	}

	[STAThread]
	static void Main() {
		Application.Run(new FontMetrik());
	}
}
