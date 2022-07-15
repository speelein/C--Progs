using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Eurokonverter {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void btnKonv_Click(object sender, RoutedEventArgs e) {
			Keyboard.Focus(tbEingabe);
			tbEingabe.SelectAll();
			if (tbEingabe.Text.Length == 0)
				return;
			double factor;
			if ((bool)rbDm2Euro.IsChecked)
				factor = 1.0 / 1.95583;
			else
				factor = 1.95583;
			double wert;
			if (!Double.TryParse(tbEingabe.Text, out wert)) {
				MessageBox.Show(this, "Die Eingabe ist nicht konvertierbar.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			} else {
				wert *= factor;
				tbAusgabe.Text = String.Format($"{wert,100:f2}");
			};
		}

		private void RadioButton_Click(object sender, RoutedEventArgs e) {
			Keyboard.Focus(tbEingabe);
			tbEingabe.SelectAll();
			tbAusgabe.Text = "";
			if ((bool)rbDm2Euro.IsChecked) {
				lblEin.Content = "DM";
				lblAus.Content = "Euro";
			} else {
				lblEin.Content = "Euro";
				lblAus.Content = "DM";
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e) {
			Keyboard.Focus(tbEingabe);
		}

		private void tbEingabe_TextChanged(object sender, TextChangedEventArgs e) {
			tbAusgabe.Text = "";
		}
	}
}
