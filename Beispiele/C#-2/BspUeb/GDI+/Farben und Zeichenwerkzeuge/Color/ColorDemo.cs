using System;
using System.Windows.Forms;
using System.Drawing;

class ColorDemo : Form {
	Color uc;
	bool puc = false;
	ColorDialog cd = new ColorDialog();

	public ColorDemo() {
		Text = "Color-Demo";
		Size = new Size(300, 210);
		Button cbColor = new Button();
		cbColor.Text = "Farbwahl";
		cbColor.Top = 70;
		cbColor.Left = 200;
		Controls.Add(cbColor);
		cbColor.Click += new EventHandler(ButtonOnClick);
	}

	protected void ButtonOnClick(object sender, EventArgs e) {
		if (cd.ShowDialog() == DialogResult.OK) {
			uc = cd.Color;
			puc = true;
			Refresh();
		}
	}

	protected override void OnPaint(PaintEventArgs e) {
		e.Graphics.DrawEllipse(new Pen(Color.Blue, 5), 50, 10, 100, 75);
		Color rot150 = Color.FromArgb(150, 255, 0, 0);
		e.Graphics.DrawEllipse(new Pen(rot150, 5), 50, 50, 100, 75);
		if (puc)
			e.Graphics.DrawEllipse(new Pen(uc, 5), 50, 90, 100, 75);
	}

	static void Main() {
		Application.Run(new ColorDemo());
	}
}