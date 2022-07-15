using System;
using System.Drawing;
using System.Windows.Forms;

public class SplitContainerDemo : Form 	{
	SplitContainer sc;

	public SplitContainerDemo() {
		Text = "SplitContainer";
		ClientSize = new Size(300,300);
	
		sc = new SplitContainer();
		sc.Parent = this;
		sc.Dock = DockStyle.Fill;
		sc.SplitterWidth = 7;
		sc.BorderStyle = BorderStyle.Fixed3D;
		sc.Panel1.Paint += new PaintEventHandler(PanelOnPaint);
		sc.Panel2.Paint += new PaintEventHandler(PanelOnPaint);
	}
		
	void PanelOnPaint(object sender, PaintEventArgs e) {
		Graphics g = e.Graphics;
		SplitterPanel pan = (SplitterPanel)sender;
		g.FillEllipse(Brushes.CornflowerBlue, 2, 2, pan.Width-7, pan.Height-7);
		if (pan == sc.Panel1)
			g.DrawString("Panel1", Font, Brushes.White, pan.Width / 2 - 24, pan.Height / 2 - 5);
		else
			g.DrawString("Panel2", Font, Brushes.White, pan.Width / 2 - 24, pan.Height / 2 - 5);
	}
	
	public static void Main() {
		Application.Run(new SplitContainerDemo());
	}
}
