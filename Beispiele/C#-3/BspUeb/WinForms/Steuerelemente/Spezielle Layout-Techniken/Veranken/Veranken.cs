using System;
using System.Windows.Forms;
using System.Drawing;

class Veranken : Form {
	Label stand;
	long anzahl;
	Button count, reset;
	
	Veranken() {
		Width = 248; Height = 150;
		Text = "Multi Purpose Counter";
		MinimumSize = new Size(Width, Height);

		stand = new Label();
		stand.Text = anzahl.ToString();
		stand.Font = new Font("Arial", 24);
		stand.Left = 20; stand.Top = 60;
		stand.Width = 200;
		stand.Height = stand.Font.Height;
		stand.BorderStyle = BorderStyle.FixedSingle;
		stand.TextAlign = ContentAlignment.MiddleRight;
		stand.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		Controls.Add(stand);

		count = new Button();
		count.Text = "Count";
		count.Left = 20; count.Top = 20;
		count.Width = 70;
		count.Anchor = AnchorStyles.Left;
		Controls.Add(count);

		reset = new Button();
		reset.Text = "Reset";
		reset.Left = 150; reset.Top = 20;
		reset.Width = 70;
		reset.Anchor = AnchorStyles.Right;
		Controls.Add(reset);

		EventHandler eh = new EventHandler(ButtonOnClick);
		count.Click += eh;
		reset.Click += eh;
	}

	void ButtonOnClick(object sender, EventArgs e) {
		if (sender == count)
			anzahl++;
		else
			anzahl = 0;
		stand.Text = anzahl.ToString();
	}

	static void Main() {
		Application.Run(new Veranken());
	}
}
