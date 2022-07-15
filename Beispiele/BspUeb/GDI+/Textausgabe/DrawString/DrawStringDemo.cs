using System.Windows.Forms;
using System.Drawing;
using System;

public class DrawStringDemo : Form {

	public DrawStringDemo() {
		Text = "DrawString-Demo";
		BackColor = SystemColors.Window;
		ClientSize = new Size(400, 150);
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;

		Font font = new Font("Arial", 12, FontStyle.Bold);
		Rectangle rect = new Rectangle(50, 50, 150, 70);

		string text = "The quick brown fox jumped of the lazy dog.";
		//string text = "The quick brown fox\n jumped of the lazy dog.";

		g.DrawRectangle(new Pen(SystemColors.WindowText), rect);
		g.DrawString(text, font, SystemBrushes.WindowText, rect);

		//g.DrawString(text, font, SystemBrushes.WindowText, 10, 10);

		//string text = "»Ich habe ja gesagt, dass er Karlsson heißt und oben "
		//  + "auf dem Dach wohnt«, sagte Lillebror. »Was ist denn da "
		//  + "Komisches dran? Die Leute dürfen doch wohl wohnen, "
		//  + "wo sie wollen!«";
		//StringFormat sf = new StringFormat();
		//sf.Alignment = StringAlignment.Center;
		//sf.LineAlignment = StringAlignment.Center;
		//Rectangle rect = new Rectangle(50, 50, 350, 100);
		//g.DrawRectangle(new Pen(SystemColors.WindowText), rect);
		//g.DrawString(text, font, SystemBrushes.WindowText, rect, sf);
		//sf.Trimming = StringTrimming.EllipsisWord;
		//rect = new Rectangle(50, 50, 150, 150);
		//g.DrawRectangle(SystemPens.WindowText, rect);
		//g.DrawString(text, font, SystemBrushes.WindowText, rect, sf);
	}

	static void Main() {
		Application.Run(new DrawStringDemo());
	}
}