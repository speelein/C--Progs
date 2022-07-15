using System;
using System.Windows.Forms;
using System.Drawing;

class ButtonDemo : Form {
	Label stand;
	long anzahl;
	Button count, reset;
	
	public ButtonDemo() {
		Height = 120; Width = 350;
		Text = "Multi Purpose Counter";
		FormBorderStyle = FormBorderStyle.FixedSingle;

		stand = new Label();
		stand.Text = anzahl.ToString();
		stand.Font = new Font("Arial", 16);
		stand.Left = 20; stand.Top = 30;
		stand.Width = 130;
		Controls.Add(stand);

        count = new Button();
		count.Text = "Count";
		count.Left = 150; count.Top = 30;
		Controls.Add(count);

        reset = new Button();
		reset.Text = "Reset";
		reset.Left = 250; reset.Top = 30;
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
		Application.Run(new ButtonDemo());
	}
}
