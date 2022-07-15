using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextBox {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		bool valToRemove = false;
		const String strInst = "Ermitteln Sie Ihre heutige Glückszahl aus Ihrem Namen!";

		public MainWindow() {
			InitializeComponent();
			info.Content = strInst;
		}

		private void button_Click(object sender, RoutedEventArgs e) {
			String vn = vorname.Text.ToUpper();
			String nn = nachname.Text.ToUpper();
			int seed = 0; // Startwert des Pseudozufallszahlengenerators
			if (vn.Length > 0 && nn.Length > 0) {
				foreach (char c in vn)
					seed += (int)c;
				foreach (char c in nn)
					seed += (int)c;
				Random zzg = new Random(DateTime.Today.Day + seed);
				info.Content = "Vertrauen Sie heute der Zahl " +
					(zzg.Next(100) + 1).ToString() + "!";
				valToRemove = true;
			}
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {
			if (valToRemove) {
				info.Content = strInst;
				valToRemove = false;
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e) {
			vorname.Focus();
		}
    }
}
