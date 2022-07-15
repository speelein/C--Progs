using System;
using System.Windows.Forms;
using System.Drawing;
using System.Resources;
using System.Reflection;


class MPC : Form {
	Label stand;
	long anzahl;
	Button count, reset;
	
	public MPC() {
		ResourceManager rm = new ResourceManager("mpc",
																				 Assembly.GetExecutingAssembly());
		Height = 120; Width = 350;
		Text = rm.GetString("TitelText");
		FormBorderStyle = FormBorderStyle.FixedDialog;

		stand = new Label();
		stand.Text = anzahl.ToString();
		stand.Font = new System.Drawing.Font("Arial", 16);
		stand.Left = 10; stand.Top = 35;
		stand.Height = stand.Font.Height;		
		stand.Width = 100;
		stand.BorderStyle = BorderStyle.FixedSingle;
		Controls.Add(stand);

		count = new Button();
		Bitmap bmp = (Bitmap)rm.GetObject("Count");
		// Transparenter Hintergrund:
		bmp.MakeTransparent(bmp.GetPixel(1, 1));
		count.Image = bmp;
		count.Left = 120; count.Top = 18;
		count.Width = count.Image.Width;
		count.Height = count.Image.Height + 8;
		Controls.Add(count);

		reset = new Button();
		reset.Image = (Bitmap)rm.GetObject("Reset");
		reset.Left = 230; reset.Top = 18;
		reset.Width = reset.Image.Width;
		reset.Height = reset.Image.Height+8;
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
		Application.Run(new MPC());
	}
}
