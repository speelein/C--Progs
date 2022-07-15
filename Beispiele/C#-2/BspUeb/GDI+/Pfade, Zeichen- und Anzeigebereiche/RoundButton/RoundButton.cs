using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class RoundButton : Form {
	Label stand;
	long anzahl;
	Button count;
	Rectangle rect;
	GraphicsPath gp;
	Pen stift, abdeckung;
	
	public RoundButton() {
		Height = 120; Width = 250;
		Text = "Multi Purpose Counter";
		FormBorderStyle = FormBorderStyle.FixedDialog;

		stand = new Label();
		stand.Text = anzahl.ToString();
		stand.Font = new Font("Arial", 16);
		stand.Left = 20; stand.Top = 30;
		stand.Width = 130;
		Controls.Add(stand);

		count = new Button();
		count.Width = 60;
		count.Height = 60;
		count.BackColor = Color.Gold;
		count.Left = 150; count.Top = 15;
		Controls.Add(count);
		count.Click += new EventHandler(ButtonOnClick);
		
		gp = new GraphicsPath();
		rect = count.ClientRectangle;
		gp.AddEllipse(rect);
		rect.Inflate(-2, -2);
		count.Region = new Region(gp);
		count.Paint += new PaintEventHandler(CountOnPaint);

		stift = new Pen(SystemColors.ControlDarkDark, 12);
		abdeckung = new Pen(SystemColors.Control, 8);
	}

	void ButtonOnClick(object sender, EventArgs e) {
			anzahl++;
			stand.Text = anzahl.ToString();
	}

	void CountOnPaint(object sender, PaintEventArgs e) {
		Graphics g = e.Graphics;
		g.SmoothingMode = SmoothingMode.HighQuality;
		if (Control.MouseButtons == MouseButtons.Left) {
			rect.Offset(0, 3);
			g.DrawEllipse(stift, rect);
			rect.Offset(0, -3);
		}
		g.DrawEllipse(stift, rect);
		g.DrawEllipse(abdeckung, rect);
	}
	static void Main() {
		Application.Run(new RoundButton());
	}
}