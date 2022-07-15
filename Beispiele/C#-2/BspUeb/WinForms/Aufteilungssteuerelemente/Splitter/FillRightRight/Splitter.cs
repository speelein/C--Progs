using System;
using System.Drawing;
using System.Windows.Forms;

public class SplitterDemo : Form 	{

	public SplitterDemo() {
		Text = "Splitter";
		ClientSize = new Size(300,200);
	
		Panel panel1 = new Panel();
		panel1.Parent = this;
		panel1.Dock = DockStyle.Fill;
		panel1.BackColor = Color.Bisque;
		panel1.Resize += new EventHandler(PanelOnResize);
		panel1.Paint += new PaintEventHandler(PanelOnPaint);
	
		Splitter split1 = new Splitter();
		split1.Parent = this;
		split1.Dock = DockStyle.Right;
		split1.Width = 5;
		split1.BackColor = SystemColors.WindowFrame;
		
		Panel panel2 = new Panel();
		panel2.Size = new Size(100,100);
		panel2.Parent = this;
		panel2.Dock = DockStyle.Right;
		panel2.BackColor = Color.AliceBlue;
		panel2.Resize += new EventHandler(PanelOnResize);
		panel2.Paint += new PaintEventHandler(PanelOnPaint);

		Splitter split2 = new Splitter();
		split2.Parent = this;
		split2.Dock = DockStyle.Right;
		split2.Width = 5;
		split2.BackColor = SystemColors.WindowFrame;

		Panel panel3 = new Panel();
		panel3.Size = new Size(100, 100);
		panel3.Parent = this;
		panel3.Dock = DockStyle.Right;
		panel3.BackColor = Color.AliceBlue;
		panel3.Resize += new EventHandler(PanelOnResize);
		panel3.Paint += new PaintEventHandler(PanelOnPaint);
	}
		
	void PanelOnPaint(object sender, PaintEventArgs e) {
		Graphics g = e.Graphics;
		Panel pan = (Panel) sender;
		g.FillEllipse(Brushes.CornflowerBlue, 1, 1, pan.Width-2, pan.Height-2);
		for (int i = 0; i < Controls.Count; i++)
			if (sender == Controls[i])
				g.DrawString("Z-Index = "+i, Font, Brushes.Beige, pan.Width / 2 - 24, pan.Height / 2 - 5);
	}
	
	void PanelOnResize(object sender, EventArgs e) {
		((Panel) sender).Refresh();
	}

	public static void Main() {
		Application.Run(new SplitterDemo());
	}
}
