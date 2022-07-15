using System;
using System.Windows.Forms;
using System.Drawing;

class ButtonDemo : Form {
	Label stand;
	long anzahl;
	Button count, reset;
	
	public ButtonDemo() {
		Height = 150; Width = 250;
		MinimumSize = new Size(Width, Height);
		Text = "Multi Purpose Counter";

		stand = new Label();
		stand.Text = anzahl.ToString();
		stand.Font = new Font("Arial", 24);
		stand.Left = 20; stand.Top = 40;
		stand.Width = Width - 46;
		stand.Height = stand.Font.Height;
		stand.BorderStyle = BorderStyle.FixedSingle;
		stand.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		Controls.Add(stand);

		count = new Button();
		count.Text = "Count";
		count.Dock = DockStyle.Top;
		Controls.Add(count);

		reset = new Button();
		reset.Text = "Reset";
		reset.Dock = DockStyle.Bottom;
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
