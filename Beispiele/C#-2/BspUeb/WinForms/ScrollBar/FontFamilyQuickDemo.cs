using System.Windows.Forms;
using System.Drawing;
using System;

public class FontFamilyQuickDemo : Form {
	Font[] fonts;
	int[] oks;	// obere Kanten der Schriftzüge, falls die Namen untereinander geschrieben werden
	int nFonts;
	Brush brush;
	VScrollBar scrollBar;
	int vStep;

	public FontFamilyQuickDemo() {
		Text = "FontFamilyDemo (performanter Rollbalken)";
		ClientSize = new Size(400, 400);
		BackColor = SystemColors.Window;
		ResizeRedraw = true;
		MouseWheel += new MouseEventHandler(FormOnMouseWheel);

		brush = new SolidBrush(SystemColors.WindowText);

		FontFamily[] ff = FontFamily.Families;
		fonts = new Font[ff.Length];
		oks = new int[ff.Length];
		FontStyle style = FontStyle.Italic;
		int size = 20;
		int vSpace = 0, i = 0;
		foreach (FontFamily aff in ff)
			if (aff.IsStyleAvailable(style)) {
				fonts[i] = new Font(aff, size, style);
				oks[i] = vSpace;
				vSpace += fonts[i].Height + 5;
				i++;
			}
		nFonts = i;
		vStep = fonts[0].Height + 5;

		scrollBar = new VScrollBar();
		scrollBar.Parent = this;
		scrollBar.Dock = DockStyle.Right;
		scrollBar.Minimum = 0;
		scrollBar.Maximum = vSpace;
		scrollBar.SmallChange = vStep;
		scrollBar.LargeChange = vStep * 5;
		scrollBar.ValueChanged += new EventHandler(VScrollBarOnValueChanged);
		//scrollBar.Scroll += new ScrollEventHandler(VScrollBarOnScroll);
	}

	void VScrollBarOnValueChanged(object sender, EventArgs e) {
		Refresh();
	}

	//void VScrollBarOnScroll(object sender, ScrollEventArgs e) {
	//  if (e.Type == ScrollEventType.EndScroll)
	//    Refresh();
	//}

	void FormOnMouseWheel(object sender, MouseEventArgs e) {
		//		MessageBox.Show(e.Delta.ToString());
		if (e.Delta > 0)
			scrollBar.Value = Math.Max(scrollBar.Minimum,
																 scrollBar.Value - scrollBar.SmallChange);
		else
			scrollBar.Value = Math.Min(scrollBar.Maximum - scrollBar.LargeChange + 1,
																 scrollBar.Value + scrollBar.SmallChange);
		Refresh();
	}

	protected override void OnPaint(PaintEventArgs e) {
		int ok = 0;
		for (int i = 0; i < nFonts; i++)
			if (oks[i] >= scrollBar.Value)
				if (ok + fonts[i].Height < ClientSize.Height) {
					e.Graphics.DrawString(fonts[i].Name, fonts[i], brush, 0, ok);
					ok += fonts[i].Height + 5;
				} else
					break;
	}

	static void Main() {
		Application.Run(new FontFamilyQuickDemo());
	}
}
