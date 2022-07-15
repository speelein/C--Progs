using System.Windows.Forms;
using System.Drawing;
using System;

public class DrawStringDemo : Form {

	DrawStringDemo() {
		Text = "DrawString-Demo";
		BackColor = SystemColors.Window;
		ClientSize = new Size(300, 100);
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;

		Font font = new Font("Arial", 12, FontStyle.Bold);
		Rectangle rect = new Rectangle(25, 25, 160, 70);

		string text = "The quick brown fox jumps over the lazy dog.";
		//string text = "The quick brown fox\n jumps over the lazy dog.";

		//g.DrawRectangle(new Pen(SystemColors.WindowText), rect);
		//g.DrawString(text, font, SystemBrushes.WindowText, rect);

		g.DrawString(text, font, SystemBrushes.WindowText, 10, 10);

		//string text = "»Ich habe ja gesagt, dass er Karlsson heißt und oben "
		//  + "auf dem Dach wohnt«, sagte Lillebror. »Was ist denn da "
		//  + "Komisches dran? Die Leute dürfen doch wohl wohnen, "
		//  + "wo sie wollen!«";
		//StringFormat sf = new StringFormat();
		//sf.Alignment = StringAlignment.Center;
		//sf.LineAlignment = StringAlignment.Center;
		//Rectangle rect = new Rectangle(50, 50, 350, 100);
		//Rectangle rect = new Rectangle(50, 50, 200, 150);
		//g.DrawString(text, font, SystemBrushes.WindowText, rect);
		//g.DrawRectangle(new Pen(SystemColors.WindowText), rect);
		//g.DrawString(text, font, SystemBrushes.WindowText, rect, sf);
		//sf.Trimming = StringTrimming.EllipsisWord;
		//rect = new Rectangle(50, 50, 150, 150);
		//g.DrawRectangle(SystemPens.WindowText, rect);
		//g.DrawString(text, font, SystemBrushes.WindowText, rect, sf);
	}

	[STAThread]
	static void Main() {
		Application.Run(new DrawStringDemo());
	}
}