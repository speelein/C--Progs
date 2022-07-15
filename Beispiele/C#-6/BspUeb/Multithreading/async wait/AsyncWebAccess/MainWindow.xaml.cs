using System;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http; // Benötigt einen Verweis auf das Assembly System.Net.Http
using System.Text.RegularExpressions;
using System.Net;
using System.Text;

namespace TitleReader {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			textBox.Text = "https://www.uni-trier.de";
		}

		private async Task<String> GetHtmlTitleAsync(String url) {
			using (var client = new HttpClient()) {
				String s = await client.GetStringAsync(url).ConfigureAwait(false);
				// Herkunft der folgenden Anweisung: https://www.dotnetperls.com/title-html
				Match m = Regex.Match(s, @"<title>\s*(.+?)\s*</title>");
				if (m.Success)
					return m.Groups[1].Value;
				else
					return null;
			}
		}

		private string GetHtmlTitle(Object urlPar) {
			String url = (String)urlPar;
			using (var client = new WebClient()) {
				client.Encoding = Encoding.UTF8;
				String s = client.DownloadString(url);
				Match m = Regex.Match(s, @"<title>\s*(.+?)\s*</title>");
				if (m.Success)
					return m.Groups[1].Value;
				else
					return null;
			}
		}

		private async void buttonTitle_Click(object sender, RoutedEventArgs e) {
			String temp = null;
			try {
				Task<String> ts = GetHtmlTitleAsync(textBox.Text);
				//Task<String> ts = Task.Factory.StartNew<String>(GetHtmlTitle, textBox.Text);

				temp = textBlock.Text;
				textBlock.Text = "Bitte warten ....";
				buttonTitle.IsEnabled = false;

				String s = await ts;
				if (s != null && s.Length > 0)
					textBlock.Text = s;
			} catch (Exception ex) {
				textBlock.Text = temp;
				MessageBox.Show(this, ex.ToString(), ex.Message);
			} finally {
				buttonTitle.IsEnabled = true;
			}
		}
	}
}
