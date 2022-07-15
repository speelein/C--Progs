using System;
using System.Windows.Forms;
using System.Drawing;

class AutoScaleDemo : Form {
	Label lbInfo;
	TextBox tbVorname, tbNachname;
	bool bValToDestroy = false;
	Button cbBigger, cbSmaller;
	
	public AutoScaleDemo() {
		Height = 200; Width = 450;
		Text = "Glückszahlengenerator";
		FormBorderStyle = FormBorderStyle.FixedSingle;
		Font = new Font("Arial", 12);
		AutoScaleBaseSize = new Size(5, 13);
		
		Label lbVorname = new Label();
		Label lbNachname = new Label();
		lbVorname.Text = "Vorname:"; lbNachname.Text = "Nachname:";
		lbVorname.Width = 60; lbNachname.Width = 65;
		lbVorname.Left = 20; lbVorname.Top = 30;
		lbNachname.Left = 230; lbNachname.Top = 30;
		Controls.Add(lbVorname); Controls.Add(lbNachname);
	
		tbVorname = new TextBox(); tbNachname = new TextBox();
		tbVorname.Left = 80; tbVorname.Top = 30; tbVorname.Width = 125;
		tbNachname.Left = 295; tbNachname.Top = 30;  tbNachname.Width = 125;
		tbVorname.TextChanged += new EventHandler(TextBoxOnTextChanged);
		tbNachname.TextChanged += new EventHandler(TextBoxOnTextChanged);
		Controls.Add(tbVorname); Controls.Add(tbNachname);
		
		Button cbGluecksZahl = new Button();
		cbGluecksZahl.Text = "Glückszahl";
		cbGluecksZahl.Top = 85;
		cbGluecksZahl.Left = 20;
		cbGluecksZahl.Width = 70;
		Controls.Add(cbGluecksZahl);
		cbGluecksZahl.TabStop = false;
		cbGluecksZahl.Click += new EventHandler(GluecksZahlOnClick);
		AcceptButton = cbGluecksZahl;

		cbBigger = new Button();
		cbBigger.Text = "Größer";
		cbBigger.Top = 125;
		cbBigger.Left = 20;
		cbBigger.Width = 70;
		Controls.Add(cbBigger);
		cbBigger.TabStop = false;
		cbBigger.Click += new EventHandler(ZoomOnClick);

		cbSmaller = new Button();
		cbSmaller.Text = "Kleiner";
		cbSmaller.Top = 125;
		cbSmaller.Left = 120;
		cbSmaller.Width = 70;
		Controls.Add(cbSmaller);
		cbSmaller.TabStop = false;
		cbSmaller.Click += new EventHandler(ZoomOnClick);
		
		lbInfo = new Label();
		lbInfo.Text = "Ermitteln Sie Ihre aktuelle Glückszahl aus Ihrem Namen!";
		lbInfo.Left = 120; lbInfo.Top = 80;
		lbInfo.AutoSize = true;
		Controls.Add(lbInfo);
	}

	void GluecksZahlOnClick(object sender, EventArgs e) {
		String vn = tbVorname.Text.ToUpper();
		String nn = tbNachname.Text.ToUpper();
		int seed = 0; // Startwert des Pseudozufallszahlengenerators
		if (vn.Length > 0 && nn.Length > 0) {
			for (int i = 0; i < vn.Length; i++)
				seed += (int) vn[i];
			for (int i = 0; i < nn.Length; i++)
				seed += (int) nn[i];
			Random zzg = new Random(DateTime.Today.Day + seed);
			lbInfo.Text = "Vertrauen Sie der Zahl " + (zzg.Next(100)+1).ToString() + "!";
			bValToDestroy = true;
		}
	}
	
    void ZoomOnClick(object sender, EventArgs e) {
	    SizeF vorher = GetAutoScaleSize(Font);
	    int fontSize = (int) Font.SizeInPoints;
	    if (sender == cbBigger) {
		    if (fontSize < 16)
			    fontSize++;
	    } else {
		    if (fontSize > 4)
			    fontSize--;
	    }
	    Font = new Font("Arial", fontSize);
	    SizeF nachher = GetAutoScaleSize(Font);
	    Scale(nachher.Width/vorher.Width, nachher.Height/vorher.Height);
    }

	
	void TextBoxOnTextChanged(object sender, EventArgs e) {
		if (bValToDestroy) {
			lbInfo.Text = "Ermitteln Sie Ihre aktuelle Glückszahl aus Ihrem Namen!";
			bValToDestroy = false;
		}
	}

	static void Main() {
		Application.Run(new AutoScaleDemo());
	}
}
