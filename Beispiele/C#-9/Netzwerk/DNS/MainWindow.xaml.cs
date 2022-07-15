using System;
using System.Windows;
using System.Net;

namespace DNS {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private async void cbToNumber_Click(object sender, RoutedEventArgs e) {
			if (tbName.Text.Length == 0)
				return;
			try {
				IPHostEntry host = await Dns.GetHostEntryAsync(tbName.Text);
				tbNumber.Text = host.AddressList[0].ToString();
			} catch (Exception ex) {
				MessageBox.Show(ex.ToString(), "Fehler");
			}
		}

		private async void cbToName_Click(object sender, RoutedEventArgs e) {
			if (tbNumber.Text.Length == 0)
				return;
			try {
				IPHostEntry host = await Dns.GetHostEntryAsync(tbNumber.Text);
				tbName.Text = host.HostName;
			} catch (Exception ex) {
				MessageBox.Show(ex.ToString(), "Fehler");
			}
		}
	}
}
