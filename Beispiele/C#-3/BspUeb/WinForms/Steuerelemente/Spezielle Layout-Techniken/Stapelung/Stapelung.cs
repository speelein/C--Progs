using System;
using System.Drawing;
using System.Windows.Forms;

class Stapelung : Form {
	Stapelung() {
		Text = "Stapelung";
		ClientSize = new Size(300,150);
		
		Label lbRed = new Label();
		lbRed.Size = new Size(250,75);
		lbRed.Left = 0;
		lbRed.BackColor = Color.Red;
		lbRed.Parent = this;
		lbRed.Click += new EventHandler(LabelOnClick);

		Label lbGreen = new Label();
		lbGreen.Size = new Size(200,100);
		lbGreen.Left = 100;
		lbGreen.BackColor = Color.Green;
		lbGreen.Parent = this; 
		lbGreen.Click += new EventHandler(LabelOnClick);

		Label lbBlue = new Label();
		lbBlue.Size = new Size(100,150);
		lbBlue.Left = 200;
		lbBlue.BackColor = Color.Blue;
		lbBlue.Parent = this;
		lbBlue.Click += new EventHandler(LabelOnClick);
	}

	void LabelOnClick(object sender, EventArgs e) {
		(sender as Control).BringToFront();
	}

	static void Main() {
		Application.Run(new Stapelung());
	}
}
