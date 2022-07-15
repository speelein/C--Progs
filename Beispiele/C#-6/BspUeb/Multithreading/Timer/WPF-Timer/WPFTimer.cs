using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;

class WPFTimer : Window {
	Label anzeige;
	DispatcherTimer tim;
	Random zzg = new Random();

	WPFTimer() {
		Height = 120; Width = 400;
		Title = "DispatcherTimer";

		StackPanel lm = new StackPanel();
		lm.VerticalAlignment = VerticalAlignment.Center;
		Content = lm;
	
		anzeige = new Label();
		anzeige.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
		lm.Children.Add(anzeige);

		tim = new DispatcherTimer();
		tim.Tick += new EventHandler(TimerAktion);
		tim.Interval = new TimeSpan(0,0,10);
		tim.Start();

		TextBox eingabe = new TextBox();
		eingabe.Width = 180;
		lm.Children.Add(eingabe);
	}

	void TimerAktion(Object myObject, EventArgs ea) {
		double zs = 0;
		anzeige.Content = "Berechnung gestartet"; // Bleibt ohne Effekt!
		for (int i = 0; i < 200000000; i++)
			zs += zzg.Next(100);
		anzeige.Content = "Aktuelle Zufallssumme: " + zs + " berechnet um " +
						  DateTime.Now.ToLongTimeString();
	}

	[STAThreadAttribute]
	static void Main() {
		new Application().Run(new WPFTimer());
	}
}