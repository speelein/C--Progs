using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Web.WebView2.Core;

namespace WebView2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
		async void InitializeAsync() {
			await webView.EnsureCoreWebView2Async(null);
		}

		void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args) {
			string uri = args.Uri;
			if (!uri.StartsWith("https://")) {
				webView.CoreWebView2.ExecuteScriptAsync(
						$"alert('{uri} ist ein unsicherer Link! Verwenden Sie nur https-Links!')");
				args.Cancel = true;
			}
		}

		public MainWindow() {
			InitializeComponent();
			try {
				InitializeAsync();
			} catch (Exception ex) {
				MessageBox.Show(ex.ToString(), "Fehler bei der WebView2-Initialisierung");
			}
			webView.NavigationStarting += EnsureHttps;
			textBox.Text = "https://www.uni-trier.de/";
			AppDomain.CurrentDomain.UnhandledException += UnHandler;
		}

		private void button3_Click(object sender, RoutedEventArgs e) {
			try {
				webView.CoreWebView2.Navigate(textBox.Text);
			} catch (Exception ex) {
				MessageBox.Show(ex.ToString(), "Fehler");
			}
		}

		private void button1_Click(object sender, RoutedEventArgs e) {
			webView.GoBack();
		}

		private void button2_Click(object sender, RoutedEventArgs e) {
			webView.GoForward();
		}

		private void UnHandler(object sender, UnhandledExceptionEventArgs e) {
			MessageBox.Show($"Unbehandelte Ausnahme: {((Exception)e.ExceptionObject).Message}");
		}
	}
}
