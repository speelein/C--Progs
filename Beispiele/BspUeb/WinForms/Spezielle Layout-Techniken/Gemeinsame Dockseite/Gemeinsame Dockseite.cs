using System;
using System.Drawing;
using System.Windows.Forms;

public class GemeinsameDockseite : Form {
	public GemeinsameDockseite() {
		Text = "Gemeinsame Dockseiten: oben, rechts, unten";
		ClientSize = new Size(400, 300);
		ResizeRedraw = true;
		ForeColor = Color.White;

		Label labRed = new Label();
		labRed.Size = new Size(100, 100);
		labRed.BackColor = Color.Red;
		labRed.Text = "0";
		labRed.Parent = this;
		labRed.Dock = DockStyle.Fill;

		Label labGreen = new Label();
		labGreen.Size = new Size(100, 100);
		labGreen.BackColor = Color.Green;
		labGreen.Text = "1";
		labGreen.Parent = this;
		labGreen.Dock = DockStyle.Top;

		Label labBlue = new Label();
		labBlue.Size = new Size(100, 100);
		labBlue.BackColor = Color.Blue;
		labBlue.Parent = this;
		labBlue.Text = "2";
		labBlue.Dock = DockStyle.Right;

		Label labGray = new Label();
		labGray.Size = new Size(100, 100);
		labGray.BackColor = Color.Gray;
		labGray.Parent = this;
		labGray.Text = "3";
		labGray.Dock = DockStyle.Bottom;

	}

	public static void Main() {
		Application.Run(new GemeinsameDockseite());
	}
}