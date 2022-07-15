using System;
using System.Windows.Forms;
using System.Drawing;
using System.Resources;
using System.Reflection;

class MultiPurposeCounter : Form {
	Label stand;
	long anzahl;
	Button count, reset;

	MultiPurposeCounter() {
		Width = 362; Height = 130;
		FormBorderStyle = FormBorderStyle.FixedDialog;

		stand = new Label();
		stand.Text = anzahl.ToString();
		stand.Font = new System.Drawing.Font("Arial", 15);
		stand.Left = 10; stand.Top = 35;
		stand.Height = stand.Font.Height;
		stand.Width = 100;
		stand.TextAlign = ContentAlignment.MiddleRight;
		stand.BorderStyle = BorderStyle.FixedSingle;
		Controls.Add(stand);

		ResourceManager rm = new ResourceManager("mpc", Assembly.GetExecutingAssembly());
		Text = rm.GetString("TitelText");

		count = new Button();
		Bitmap bmp = (Bitmap)rm.GetObject("Count");
		bmp.MakeTransparent(bmp.GetPixel(1, 1));
		count.Image = bmp;
		count.Left = 120; count.Top = 18;
		count.Width = count.Image.Width + 8;
		count.Height = count.Image.Height + 8;
		Controls.Add(count);

		reset = new Button();
		bmp = (Bitmap)rm.GetObject("Reset");
		bmp.MakeTransparent(bmp.GetPixel(1, 1));
		reset.Image = bmp;
		reset.Left = 236; reset.Top = 18;
		reset.Width = reset.Image.Width + 8;
		reset.Height = reset.Image.Height + 8;
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


	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new MultiPurposeCounter());
	}
}
