using System;
using System.Windows.Forms;

class WinFormsTimer : Form {
	Label anzeige;
	Random zzg;

	public WinFormsTimer() {
		Height = 130; Width = 350;
		Text = "System.Windows.Forms.Timer";
		anzeige = new Label();
		anzeige.Width = 300;
		anzeige.Left = 20; anzeige.Top = 20;
		Controls.Add(anzeige);
		zzg = new Random();

		Timer tim = new Timer();
		tim.Tick += new EventHandler(TimerAktion);
		tim.Interval = 1000;
		tim.Start();

		TextBox eingabe = new TextBox();
		eingabe.Left = 20; eingabe.Top = 50; eingabe.Width = 180;
		Controls.Add(eingabe);
	}

	//void TimerAktion(Object myObject, EventArgs myEventArgs) {
	//    long l = 0;
	//    for (int i = 0; i < 10000000; i++)
	//        l += zzg.Next(100);
	//    anzeige.Text = "Aktuelle Zufallssumme: " + l.ToString() +
	//        " berechnet um " + DateTime.Now.ToLongTimeString();
	//}
	
	void TimerAktion(Object myObject, EventArgs myEventArgs) {
		long l = 0;
		for (int j = 0; j < 100; j++) {
			Application.DoEvents();
			for (int i = 0; i < 100000; i++)
				l += zzg.Next(100);
		}
		anzeige.Text = "Aktuelle Zufallssumme: " + l.ToString() +
			" berechnet um " + DateTime.Now.ToLongTimeString();
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new WinFormsTimer());
	}
}
