using System;
using System.Windows.Forms;
using System.Drawing;

class PanelTrick : Form {
	public PanelTrick() {
		Text = "PanelTrick";
		Size = new Size(330, 170);
		ResizeRedraw = true;

		Panel pan = new Panel();
		pan.Parent = this;
		pan.Dock = DockStyle.Fill;
		pan.AutoScroll = true;
		pan.Paint += new PaintEventHandler(PanelOnPaint);

		StatusBar sb = new StatusBar();
		sb.Parent = this;
		sb.Text = "Statuszeile u. Panel teilen sich den Klientenbereich.";

		Label lb = new Label();
		lb.Location = new Point(50, 50);
		lb.AutoSize = true;
		lb.Text = "Die Linie wird auf das Panel-Objekt gezeichnet.";
		lb.Parent = pan;
	}
	protected void PanelOnPaint(object sender, PaintEventArgs e) {
		Pen stift = new Pen(Color.Black, 5);
		Panel pan = (Panel)sender;
		e.Graphics.DrawLine(stift, 0, 0, pan.ClientSize.Width, pan.ClientSize.Height);
	}
	static void Main() {
		Application.Run(new PanelTrick());
	}
}