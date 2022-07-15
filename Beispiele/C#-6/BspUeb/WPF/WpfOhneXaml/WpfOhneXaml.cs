using System.Windows;

class WpfOhneXaml : Window {
	WpfOhneXaml() {
		Title = "WPF ohne XAML";
		Width = 300;
		Height = 100;
	}

	[System.STAThread]
	static void Main() {
		Application app = new Application();
		WpfOhneXaml hf = new WpfOhneXaml();
		app.Run(hf);
	}
}
