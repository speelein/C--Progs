using System;
using System.Windows.Forms;
using System.Drawing;

class ButtonDemo : Form {
	Label stand;
	long anzahl;
	Button count, reset;
	
    public ButtonDemo() {
	    Height = 150; Width = 250;
	    Text = "Multi Purpose Counter";
	    MinimumSize = new Size(Width, Height);
	    stand = new Label();
	    stand.Text = anzahl.ToString();
	    stand.Font = new Font("Arial", 24);
	    stand.Left = 20; stand.Top = 60;
	    stand.Width = Width - 46;
	    stand.Height = stand.Font.Height;
	    stand.BorderStyle = BorderStyle.FixedSingle;

        stand.Anchor = AnchorStyles.Left | AnchorStyles.Right;
	    Controls.Add(stand);

	    count = new Button();
	    count.Text = "Count";
	    count.Left = 20; count.Top = 20;
	    count.Anchor = AnchorStyles.Left;
	    Controls.Add(count);

	    reset = new Button();
	    reset.Text = "Reset";
	    reset.Left = 150; reset.Top = 20;
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
		Application.Run(new ButtonDemo());
	}
}
