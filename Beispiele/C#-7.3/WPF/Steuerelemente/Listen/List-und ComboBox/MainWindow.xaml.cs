
using System.Windows;
using System.Windows.Controls;

namespace ListBox {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
			MessageBox.Show("Guten Tag, " + ((TextBlock)listBox.SelectedItem).Text + " " +
				comboBox.Text);
        }
	}
}
