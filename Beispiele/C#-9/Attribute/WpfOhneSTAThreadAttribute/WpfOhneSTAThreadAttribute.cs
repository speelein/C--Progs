using System.Windows;

class WpfOhneSTAThreadAttribute : Window {
	WpfOhneSTAThreadAttribute() {
		Title = "WPF ohne XAML";
		Width = 300;
		Height = 100;
	}

	//[System.STAThread]
	static void Main() {
		Application app = new Application();
		WpfOhneSTAThreadAttribute hf = new WpfOhneSTAThreadAttribute();
		app.Run(hf);
	}
}
