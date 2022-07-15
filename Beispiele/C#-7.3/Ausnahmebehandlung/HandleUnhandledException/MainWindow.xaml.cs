using System.Windows;

namespace HandleUnhandledException {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void button1_Click(object sender, RoutedEventArgs e) {
			int i = 0;
			label.Content = (10/i).ToString();
		}

		private void button2_Click(object sender, RoutedEventArgs e) {
			int i = 10;
			label.Content = (10 / i).ToString();
		}
	}
}
