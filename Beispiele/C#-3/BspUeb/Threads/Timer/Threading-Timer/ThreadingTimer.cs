using System;
using System.Windows.Forms;
using System.Threading;

delegate void LabelUpdateDelegate(string s);

class ThreadingTimer : Form {
	Label anzeige;
	System.Threading.Timer tim;
	Random zzg;
	LabelUpdateDelegate laup;

	public ThreadingTimer() {
		Height = 130; Width = 350;
		Text = "System.Threading.Timer";
		anzeige = new Label();
		anzeige.Width = 300;
		anzeige.Left = 20; anzeige.Top = 20;
		Controls.Add(anzeige);
		zzg = new Random();
		laup = new LabelUpdateDelegate(this.UpdateLabel);
		tim = new System.Threading.Timer(this.HintergrundAktion, null, 0, 1000);

		TextBox eingabe = new TextBox();
		eingabe.Left = 20; eingabe.Top = 50; eingabe.Width = 180;
		Controls.Add(eingabe);
	}

	void HintergrundAktion(object info) {
		long l = 0;
		for (int i = 0; i < 10000000; i++)
			l += zzg.Next(100);
		BeginInvoke(laup, l.ToString());
	}

	void UpdateLabel(string s) {
		anzeige.Text = "Aktuelle Zufallssumme: " + s + " berechnet um " +
			DateTime.Now.ToLongTimeString();
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new ThreadingTimer());
	}
}