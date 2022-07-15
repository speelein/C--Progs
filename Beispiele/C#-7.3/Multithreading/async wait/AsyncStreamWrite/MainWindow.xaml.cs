using System;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http; // Benötigt einen Verweis auf das Assembly System.Net.Http
using System.IO;

namespace AsyncStreamWrite {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			textBox.Text = "https://www.uni-trier.de";
		}

		private async Task GetHtmlCodeAsync(String url) {
			String s = null;
			using (var client = new HttpClient()) {
				s = await client.GetStringAsync(url).ConfigureAwait(false);
			}
			using (var stream = new FileStream("demo.txt", FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true)) {
				var utf8enc = new System.Text.UTF8Encoding();
				byte[] sb = utf8enc.GetBytes(s);
				await stream.WriteAsync(sb, 0, sb.Length).ConfigureAwait(false);
			}
		}

		private async void Button_Click(object sender, RoutedEventArgs e) {
			String temp = null;
			try {
                button.IsEnabled = false;
                Task ts = GetHtmlCodeAsync(textBox.Text);

				temp = result.Text;
				result.Text = "Bitte warten ....";

				await ts;
				if (ts.Status == TaskStatus.RanToCompletion)
					result.Text = "Ready";
			} catch (Exception ex) {
				result.Text = temp;
				MessageBox.Show(this, ex.ToString(), ex.Message);
			} finally {
				button.IsEnabled = true;
			}
		}
	}
}
