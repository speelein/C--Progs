using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class RoundButton : Button {
	Rectangle rect;
	Pen stift, abdeckung;
	bool pressed;

	public RoundButton() {
		Width = 60;
		Height = 60;
		GraphicsPath gp = new GraphicsPath();
		rect = ClientRectangle;
		gp.AddEllipse(rect);
		Region = new Region(gp);
		stift = new Pen(SystemColors.ControlDarkDark, 5);
		abdeckung = new Pen(SystemColors.ControlDarkDark, 8);
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		g.SmoothingMode = SmoothingMode.HighQuality;
		if (pressed) {
			rect.Offset(0, 3);
			g.FillEllipse(Brushes.Gold, rect);
			g.DrawEllipse(abdeckung, rect);
			rect.Offset(0, -3);
			g.DrawEllipse(stift, rect);
		} else {
			g.FillEllipse(Brushes.Gold, rect);
			g.DrawEllipse(stift, rect);
		}
	}

	protected override void OnMouseDown(MouseEventArgs e) {
		base.OnMouseDown(e);
		if (e.Button == MouseButtons.Left) {
			pressed = true;
			Refresh();
		}
	}

	//protected override void OnMouseLeave(EventArgs e) {
	//    MessageBox.Show("MouseLeave");
	//    base.OnMouseLeave(e);
	//    pressed = false;
	//    Refresh();
	//}

	protected override void OnMouseUp(MouseEventArgs e) {
		base.OnMouseUp(e);
		pressed = false;
		Refresh();
	}

}

class RoundButtonDemo : Form {
	Label stand;
	long anzahl;
	RoundButton count;
	
	public RoundButtonDemo() {
		Text = "Multi Purpose Counter";
		Width = 270;
		Height = 120;
		MinimumSize = new Size(Width, Height);

		stand = new Label();
		stand.Text = anzahl.ToString();
		stand.Font = new Font("Arial", 16);
		stand.Left = 20; stand.Top = 30;
		stand.Width = 130;
		Controls.Add(stand);

		count = new RoundButton();
		count.Left = 150; count.Top = 15;
		Controls.Add(count);
		count.Click += new EventHandler(ButtonOnClick);
	}

	void ButtonOnClick(object sender, EventArgs e) {
			anzahl++;
			stand.Text = anzahl.ToString();
	}

	[STAThread]
	static void Main() {
		Application.Run(new RoundButtonDemo());
	}
}