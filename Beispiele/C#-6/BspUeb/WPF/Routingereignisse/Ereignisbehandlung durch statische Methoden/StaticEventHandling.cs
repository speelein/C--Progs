using System;
using System.Windows;
using System.Windows.Controls;

class MaiButton : Button {
	protected static void StaticClickEventHandler(object sender, RoutedEventArgs e) {
		MessageBox.Show("Statischer Click-Handler der Klasse MaiButton");
	}
	static MaiButton () {
		EventManager.RegisterClassHandler(typeof(MaiButton), ClickEvent,
			new RoutedEventHandler(StaticClickEventHandler), true);
	}
}

class StaticEventHandling : Window {
	StaticEventHandling() {
		Height = 140; Width = 450;
		Title = "Ereignisbehandlung durch statische Methoden";
		StackPanel lm = new StackPanel();
		lm.Orientation = Orientation.Horizontal;
        lm.HorizontalAlignment = HorizontalAlignment.Center;
        lm.VerticalAlignment = VerticalAlignment.Center;
        Content = lm;
		MaiButton k1 = new MaiButton(); k1.Content = "Knopf 1"; k1.Width = 100;
		k1.Margin = new Thickness(20); lm.Children.Add(k1);
		MaiButton k2 = new MaiButton(); k2.Content = "Knopf 2"; k2.Width = 100;
		k2.Margin = new Thickness(20); lm.Children.Add(k2);

		k1.Click += new RoutedEventHandler(knopf1Click);
	}

	private void knopf1Click(object sender, RoutedEventArgs e) {
		MessageBox.Show("Click-Handler von Knopf 1");
	}

	[STAThread]
	static void Main() {
		new Application().Run(new StaticEventHandling());
	}
}