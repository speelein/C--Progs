using System;
using System.Windows.Forms;
using System.Drawing;

class Konfusion : Form {
	public Konfusion() {
		Text = "Konfusion";
		Size = new Size(250, 200);
		ResizeRedraw = true;
		StatusBar sb = new StatusBar();
		sb.Parent = this;

		AutoScroll = true;
		Label lb = new Label();
		lb.Location = new Point(250, 150);
		lb.AutoSize = true;
		lb.Text = "Such die Statuszeile!";
		lb.Parent = this;
		sb.Text = "Diese \"Statuszeile\" muss mühsam nach oben gerollt werden.";
	}
	static void Main() {
		Application.Run(new Konfusion());
	}
}