using System;
using System.Drawing;
using System.Windows.Forms;

public class Stapelung : Form {
	public Stapelung() {
	Text = "Stapelung";
	ClientSize = new Size(300,150);
	
	Label labRed = new Label();
	labRed.Size = new Size(250,75);
	labRed.Left = 0;
	labRed.BackColor = Color.Red;
	labRed.Parent = this;
	labRed.Click += new EventHandler(PanelOnClick);

	Label labGreen = new Label();
	labGreen.Size = new Size(200,100);
	labGreen.Left = 100;
	labGreen.BackColor = Color.Green;
	labGreen.Parent = this; 
	labGreen.Click += new EventHandler(PanelOnClick);

	Label labBlue = new Label();
	labBlue.Size = new Size(100,150);
	labBlue.Left = 200;
	labBlue.BackColor = Color.Blue;
	labBlue.Parent = this;
	labBlue.Click += new EventHandler(PanelOnClick);
}

	void PanelOnClick(object sender, EventArgs e) {
		(sender as Control).BringToFront();
	}

	public static void Main() {
		Application.Run(new Stapelung());
	}
}
