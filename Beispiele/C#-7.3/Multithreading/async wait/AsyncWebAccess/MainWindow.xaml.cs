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
			textBox.Text = "https://www.heise.de/newsticker/";
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

		private async void ButtonTitle_Click(Object sender, RoutedEventArgs e) {
			String temp = null;
			try {
                buttonTitle.IsEnabled = false;
                Task<String> ts = GetHtmlTitleAsync(textBox.Text);

                temp = textBlock.Text;
                textBlock.Text = "Bitte warten ....";

				String s = await ts;
				if (s != null && s.Length > 0)
					textBlock.Text = s;
                else
                    textBlock.Text = "Kein vorzeigbares Ergebnis";
            } catch (Exception ex) {
                textBlock.Text = temp;
				MessageBox.Show(this, ex.ToString(), ex.Message);
			} finally {
				buttonTitle.IsEnabled = true;
            }
		}
	}
}
