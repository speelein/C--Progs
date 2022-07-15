using System.Windows.Forms;
using System.Drawing;
using System;

public class FontFamilyDemo : Form {
	Font[] fonts;
	int nFonts;

	public FontFamilyDemo() {
		Text = "FontFamily-Demo";
		BackColor = SystemColors.Window;
		ClientSize = new Size(400, 300);
		AutoScroll = true;
		FontFamily[] ff = FontFamily.Families;
		fonts = new Font[ff.Length];
		FontStyle style = FontStyle.Italic | FontStyle.Bold;
		int size = 16;
		int vs = 0, i = 0;
		foreach (FontFamily aff in ff)
			if (aff.IsStyleAvailable(style)) {
				fonts[i] = new Font(aff, size, style);
				vs += fonts[i].Height + 5;
				i++;
			}
		nFonts = i;
		Panel pan = new Panel();
		pan.Height = vs;
		pan.Dock = DockStyle.Top;
		pan.Paint += new PaintEventHandler(PanelOnPaint);
		pan.Parent = this;
	}

	void PanelOnPaint(object sender, PaintEventArgs e) {
		int ok = 0;
		for (int i = 0; i < nFonts; i++) {
			e.Graphics.DrawString(fonts[i].Name, fonts[i], SystemBrushes.WindowText, 0, ok);
			ok += fonts[i].Height + 5;
		}
	}

	static void Main() {
		Application.Run(new FontFamilyDemo());
	}
}
