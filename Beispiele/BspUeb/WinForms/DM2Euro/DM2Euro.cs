using System;
using System.Windows.Forms;
using System.Drawing;

class DM2Euro : Form {
    TextBox tbDM;
    Label lbEuroWert;
    const double FAKTOR = 1.95583;
    bool bValToRemove;

    public DM2Euro() {
	    Height = 150; Width = 450;
	    Text = "Eurokonverter";
	    FormBorderStyle = FormBorderStyle.FixedSingle;
	    AutoScaleBaseSize = new Size(5, 13);
    	
	    Label lbDM = new Label();
	    lbDM.Text = "DM:";
	    lbDM.Width = 60;
	    lbDM.Left = 20;
        lbDM.Top = 35;
	    Controls.Add(lbDM);

        Label lbEuro = new Label();
        lbEuro.Text = "Euro:";
        lbEuro.Width = 65;
        lbEuro.Left = 230;
        lbEuro.Top = 35;
        Controls.Add(lbEuro);

	    tbDM = new TextBox();
	    tbDM.Left = 80;
        tbDM.Top = 30;
        tbDM.Width = 125;
        tbDM.TextChanged += new EventHandler(DmOnTextChanged);
        Controls.Add(tbDM);

        lbEuroWert = new Label();
        lbEuroWert.Text = "";
        lbEuroWert.Left = 295;
        lbEuroWert.Top = 30;
        lbEuroWert.Width = 125;
        lbEuroWert.BorderStyle = BorderStyle.Fixed3D;
        lbEuroWert.TextAlign = ContentAlignment.MiddleLeft;
        Controls.Add(lbEuroWert);

	    Button cbKonvertieren = new Button();
	    cbKonvertieren.Text = "Konvertieren";
	    cbKonvertieren.Top = 80;
        cbKonvertieren.Left = 20;
        cbKonvertieren.Width = 80;
	    Controls.Add(cbKonvertieren);
	    cbKonvertieren.TabStop = false;
	    cbKonvertieren.Click += new EventHandler(KonvertierenOnClick);
	    AcceptButton = cbKonvertieren;
    }

    void KonvertierenOnClick(object sender, EventArgs e) {
        try {
            double euraw = Convert.ToDouble(tbDM.Text) / FAKTOR;
            long euro = (long)euraw;
            byte cent = (byte)((euraw - euro) * 100 + 0.5);
            lbEuroWert.Text = euro.ToString() + "," + cent.ToString();
        } catch { }
        bValToRemove = true;
    }

    void DmOnTextChanged(object sender, EventArgs e) {
	    if (bValToRemove) {
            lbEuroWert.Text = "";
		    bValToRemove = false;
	    }
    }
	
	static void Main() {
        Application.Run(new DM2Euro());
	}
}
