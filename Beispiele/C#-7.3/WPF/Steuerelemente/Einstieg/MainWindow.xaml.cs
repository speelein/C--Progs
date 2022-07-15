using System.Windows;
using System.Windows.Media;

namespace Steuerelemente {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			this.Background = Brushes.Beige;
		}

		private void button_Click(object sender, RoutedEventArgs e) {
            Background = (Background == Brushes.Beige) ? Brushes.LightGray : Brushes.Beige;
        }
	}
}
