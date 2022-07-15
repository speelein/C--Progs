using System;
using System.Windows;
using System.Threading;
using System.Windows.Controls;

delegate void LabelUpdateDelegate(String s);

class ThreadingTimer : Window {
	Label anzeige;
	Timer tim;
	Random zzg = new Random();

	ThreadingTimer() {
		Height = 120; Width = 400;
		Title = "System.Threading.Timer";

		var lm = new StackPanel();
		lm.VerticalAlignment = VerticalAlignment.Center;
		Content = lm;
	
		anzeige = new Label();
		anzeige.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
		lm.Children.Add(anzeige);

		tim = new Timer(new TimerCallback(HintergrundAktion), null, 0, 10000);

		TextBox eingabe = new TextBox();
		eingabe.Width = 180;
		lm.Children.Add(eingabe);
	}

	void Melde (String s) {
        Action action = delegate () {anzeige.Content = s;};
        anzeige.Dispatcher.BeginInvoke(action);
	}

	void HintergrundAktion(Object info) {
		double zs = 0;
		Melde("Berechnung gestartet");
		for (int i = 0; i < 200_000_000; i++)
			zs += zzg.Next(100);
		Melde("Aktuelle Zufallssumme: " + zs.ToString() +
			  " berechnet um " + DateTime.Now.ToLongTimeString());
	}

	[STAThreadAttribute]
	static void Main() {
		new Application().Run(new ThreadingTimer());
	}
}