using System;
using System.Drawing;
using System.Windows.Forms;

public class SplitterDemo : Form 	{

	public SplitterDemo() {
		Text = "Splitter";
		ClientSize = new Size(300,200);
	
		Panel panel0 = new Panel();
		panel0.Parent = this;
		panel0.Dock = DockStyle.Fill;
		panel0.BackColor = Color.Bisque;
		panel0.Resize += new EventHandler(PanelOnResize);
		panel0.Paint += new PaintEventHandler(PanelOnPaint);
	
		Splitter split1 = new Splitter();
		split1.Parent = this;
		split1.Dock = DockStyle.Left;
		split1.MinSize = 0;
		split1.MinExtra = 0;
		split1.Width  = 7;
		split1.BackColor = SystemColors.Control;
		split1.BorderStyle = BorderStyle.FixedSingle;
		
		Panel panel1 = new Panel();
		panel1.Parent = this;
		panel1.Dock = DockStyle.Left;
		panel1.BackColor = Color.AliceBlue;
		panel1.Resize += new EventHandler(PanelOnResize);
		panel1.Paint += new PaintEventHandler(PanelOnPaint);

		Panel panel11 = new Panel();
		panel11.Parent = panel1;
		panel11.Dock = DockStyle.Fill;
		panel11.BackColor = Color.Bisque;
		panel11.Resize += new EventHandler(PanelOnResize);
		panel11.Paint += new PaintEventHandler(PanelOnPaint);
		
		Splitter split2 = new Splitter();
		split2.Parent = panel1;
		split2.Dock = DockStyle.Bottom;
		split2.Height  = 7;
		split2.BackColor = SystemColors.Control;
		split2.BorderStyle = BorderStyle.FixedSingle;
		
		Panel panel12 = new Panel();
		panel12.Parent = panel1;
		panel12.Dock = DockStyle.Bottom;
		panel12.BackColor = Color.AliceBlue;
		panel12.Resize += new EventHandler(PanelOnResize);
		panel12.Paint += new PaintEventHandler(PanelOnPaint);
	}
		
	void PanelOnPaint(object sender, PaintEventArgs e) {
		Graphics g = e.Graphics;
		Panel pan = (Panel) sender;
		g.FillEllipse(Brushes.CornflowerBlue, 1, 1, pan.Width-2, pan.Height-2);
		for (int i = 0; i < ((Control)sender).Parent.Controls.Count; i++)
			if (sender == ((Control)sender).Parent.Controls[i])
				g.DrawString("Z-Index = " + i, Font, Brushes.Beige, pan.Width / 2 - 24, pan.Height / 2 - 5);
	}
	
	void PanelOnResize(object sender, EventArgs e) {
		((Panel) sender).Invalidate();
	}

	public static void Main() {
		Application.Run(new SplitterDemo());
	}
}
