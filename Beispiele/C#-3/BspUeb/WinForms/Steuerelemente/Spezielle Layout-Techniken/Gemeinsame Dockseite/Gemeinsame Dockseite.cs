using System;
using System.Drawing;
using System.Windows.Forms;

public class GemeinsameDockseite : Form {
	GemeinsameDockseite() {
		Text = "Gemeinsame Dockseiten: Links";
		ClientSize = new Size(300, 100);
		ForeColor = Color.White;

		Label lbRed = new Label();
		lbRed.BackColor = Color.Red;
		lbRed.Text = "0";
		lbRed.Parent = this;
		lbRed.Dock = DockStyle.Fill;

		Label lbGreen = new Label();
		lbGreen.Width = 100;
		lbGreen.BackColor = Color.Green;
		lbGreen.Text = "1";
		lbGreen.Parent = this;
		lbGreen.Dock = DockStyle.Left;

		Label lbBlue = new Label();
		lbBlue.Width = 100;
		lbBlue.BackColor = Color.Blue;
		lbBlue.Parent = this;
		lbBlue.Text = "2";
		lbBlue.Dock = DockStyle.Left;
	}

	static void Main() {
		Application.Run(new GemeinsameDockseite());
	}
}