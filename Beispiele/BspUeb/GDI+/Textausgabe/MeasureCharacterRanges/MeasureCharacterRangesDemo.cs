using System.Windows.Forms;
using System.Drawing;
using System;

public class MeasureCharacterRangesDemo : Form {
	Brush brush;
	Font[] fonts;
	string[] texte;

	public MeasureCharacterRangesDemo() {
		Text = "MeasureCharacterRanges-Demo";
		BackColor = SystemColors.Window;
		ClientSize = new Size(440, 50);
		brush = new SolidBrush(SystemColors.WindowText);
		FontFamily ffar = new FontFamily("Arial");
		Font fontRegular = new Font(ffar, 16, FontStyle.Regular);
		Font fontItalic = new Font(ffar, 16, FontStyle.Italic);
		fonts = new Font[] { fontRegular, fontItalic, fontRegular };
		texte = new string[] { "Oh, welch ein schrecklich", " schräges ", "Wort!" };
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		PointF pkt = new PointF(10, 10);
		for (int i = 0; i < 3; i++) {
			g.DrawString(texte[i], fonts[i], brush, pkt);
			int width = MeasureDisplayStringWidth(e.Graphics, texte[i], fonts[i]);
			g.DrawRectangle(Pens.Red, pkt.X, pkt.Y, width, 25);
			pkt.X += width;
		}
	}

	// Vorschlag von Pierre Arnaud (http://www.codeproject.com/cs/media/measurestring.asp):
	static public int MeasureDisplayStringWidth(Graphics graphics, string text, Font font) {
		StringFormat format = new StringFormat();
		RectangleF rect = new RectangleF(0, 0, 1000, 1000);
		CharacterRange[] ranges = { new CharacterRange(0, text.Length) };
		Region[] regions = new Region[1];
		format.SetMeasurableCharacterRanges(ranges);
		regions = graphics.MeasureCharacterRanges(text, font, rect, format);
		rect = regions[0].GetBounds(graphics);
		return (int)(rect.Right + 1.0f);
	}

	static void Main() {
		Application.Run(new MeasureCharacterRangesDemo());
	}
}
