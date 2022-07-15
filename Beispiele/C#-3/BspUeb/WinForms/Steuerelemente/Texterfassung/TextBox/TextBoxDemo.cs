using System;
using System.Windows.Forms;
using System.Drawing;

class TextBoxDemo : Form {
    Label lbInfo;
    TextBox tbVorname, tbNachname;
	bool bValToRemove = false;
    String strInst = "Ermitteln Sie Ihre heutige Glückszahl aus Ihrem Namen!";
	
    TextBoxDemo() {
		Width = 450; Height = 150;
	    Text = "Glückszahlengenerator";
		FormBorderStyle = FormBorderStyle.FixedSingle;
    	
	    Label lbVorname = new Label(); Label lbNachname = new Label();
	    lbVorname.Text = "Vorname:"; lbNachname.Text = "Nachname:";
	    lbVorname.Width = 60; lbNachname.Width = 65;
	    lbVorname.Left = 20; lbVorname.Top = 30;
	    lbNachname.Left = 230; lbNachname.Top = 30;
	    Controls.Add(lbVorname); Controls.Add(lbNachname);

	    tbVorname = new TextBox(); tbNachname = new TextBox();
	    tbVorname.Left = 80; tbVorname.Top = 30; tbVorname.Width = 125;
	    tbNachname.Left = 295; tbNachname.Top = 30; tbNachname.Width = 125;
        EventHandler eh = new EventHandler(TextBoxOnTextChanged);
        tbVorname.TextChanged += eh;
        tbNachname.TextChanged += eh;
	    Controls.Add(tbVorname); Controls.Add(tbNachname);

		//tbVorname.Multiline = true;
		//tbVorname.Height = 32;
		//tbVorname.ScrollBars = ScrollBars.Vertical;

	    Button cbGluecksZahl = new Button();
	    cbGluecksZahl.Text = "Glückszahl";
	    cbGluecksZahl.Top = 80; cbGluecksZahl.Left = 20; cbGluecksZahl.Width = 70;
	    Controls.Add(cbGluecksZahl);
	    cbGluecksZahl.TabStop = false;
	    cbGluecksZahl.Click += new EventHandler(ButtonOnClick);
	    AcceptButton = cbGluecksZahl;
    	
	    lbInfo = new Label();
	    lbInfo.Text = strInst;
	    lbInfo.Left = 120; lbInfo.Top = 85;
	    lbInfo.AutoSize = true;
	    Controls.Add(lbInfo);
    }

    void ButtonOnClick(object sender, EventArgs e) {
	    String vn = tbVorname.Text.ToUpper();
	    String nn = tbNachname.Text.ToUpper();
	    int seed = 0; // Startwert des Pseudozufallszahlengenerators
	    if (vn.Length > 0 && nn.Length > 0) {
		    foreach (char c in vn)
			    seed += (int) c;
			foreach (char c in nn)
				seed += (int)c;
			Random zzg = new Random(DateTime.Today.Day + seed);
		    lbInfo.Text = "Vertrauen Sie heute der Zahl " + (zzg.Next(100)+1).ToString() + "!";
		    bValToRemove = true;
	    }
    }

    void TextBoxOnTextChanged(object sender, EventArgs e) {
	    if (bValToRemove) {
		    lbInfo.Text = strInst;
		    bValToRemove = false;
	    }
    }
	
	static void Main() {
		Application.Run(new TextBoxDemo());
	}
}
