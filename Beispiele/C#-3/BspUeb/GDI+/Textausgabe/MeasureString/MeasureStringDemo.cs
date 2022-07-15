using System.Windows.Forms;
using System.Drawing;
using System;

class MeasureStringDemo : Form {
	Brush brush = SystemBrushes.WindowText;
	Font[] fonts;
	string[] texte;

	MeasureStringDemo() {
		Text = "MeasureString-Demo";
		BackColor = SystemColors.Window;
		ClientSize = new Size(440, 50);
		FontFamily ffar = new FontFamily("Arial");
		Font fontRegular = new Font(ffar, 16, FontStyle.Regular);
		Font fontItalic = new Font(ffar, 16, FontStyle.Italic);
		fonts = new Font[] {fontRegular, fontItalic, fontRegular};
		texte = new string[] { "Oh, welch ein schrecklich", " schräges", " Wort!" };
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		PointF pkt = new PointF(10, 10);
		SizeF size;
		StringFormat sf = StringFormat.GenericTypographic;
		sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
		//g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
		for (int i = 0; i < 3; i++) {
			g.DrawString(texte[i], fonts[i], brush, pkt, sf);
			size = g.MeasureString(texte[i], fonts[i], pkt, sf);
			//g.DrawString(texte[i], fonts[i], brush, pkt);
			//size = g.MeasureString(texte[i], fonts[i]);
			g.DrawRectangle(Pens.Red, pkt.X, pkt.Y, size.Width, size.Height);
			pkt.X += size.Width;
		}
	}

	[STAThread]
	static void Main() {
		Application.Run(new MeasureStringDemo());
	}
}
