using System;
using System.Windows.Forms;
using EuroKonverter;

class COMClientCs : Form {
	Label lbErgebnis;
	TextBox tbEuro;
	BetragClass betrag = new BetragClass();
	
	public COMClientCs() {
		Height = 200; Width = 210;
		Text = "Euro-Konverter";
		FormBorderStyle = FormBorderStyle.FixedSingle;
		
		Label lbEuro = new Label();
		lbEuro.Text = "Euro-Betrag:";
		lbEuro.Left = 20; lbEuro.Top = 30; lbEuro.Width = 80;
		lbEuro.Parent = this;

		Label lbDM = new Label();
		lbDM.Text = "DM-Betrag:";
		lbDM.Left = 20;	lbDM.Top = 80; lbDM.Width = 80;
		lbDM.Parent = this;
		
		lbErgebnis = new Label();
		lbErgebnis.Text = "";
		lbErgebnis.Left = 100; lbErgebnis.Top = 80;
		lbErgebnis.Parent = this;

		tbEuro = new TextBox();
		tbEuro.Left = 100; tbEuro.Top = 30; tbEuro.Width = 80;
		tbEuro.Parent = this;
		
		Button cbUmrechnen = new Button();
		cbUmrechnen.Text = "Umrechnen!";
		cbUmrechnen.Top = 120; cbUmrechnen.Left = 20; cbUmrechnen.Width = 160;
		cbUmrechnen.Parent = this;
		cbUmrechnen.Click += new EventHandler(ButtonOnClick);
	}

	void ButtonOnClick(object sender, EventArgs e) {
		if (tbEuro.Text.Length > 0) {
			double d;
			try {
				d = double.Parse(tbEuro.Text);
			} catch {
				lbErgebnis.Text  = "Falsche Eingabe!";
				return;
			}
			betrag.SetEuro(d);
			lbErgebnis.Text = betrag.GetDM().ToString();
		}
	}

	static void Main() {
		Application.Run(new COMClientCs());
	}
}
