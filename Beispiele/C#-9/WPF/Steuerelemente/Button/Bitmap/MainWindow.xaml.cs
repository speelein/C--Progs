using System.Windows;
using System.Windows.Input;

namespace ButtonBitmap {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
        long anzahl;

		public MainWindow() {
			InitializeComponent();
		}

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (e.Source == count)
                anzahl++;
            else
                anzahl = 0;
            label.Content = anzahl.ToString();
        }
	}
}
