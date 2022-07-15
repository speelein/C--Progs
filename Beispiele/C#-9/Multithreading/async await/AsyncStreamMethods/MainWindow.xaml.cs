using System;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http;
using System.IO;

namespace AsyncStreamMethods {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		static HttpClient client = new();

		public MainWindow() {
			InitializeComponent();
			textBox.Text = "https://www.uni-trier.de";
		}

		//private async Task GetHtmlCodeAsync(string uri) {
		//	try {
		//		string s = await client.GetStringAsync(uri).ConfigureAwait(false);
		//		using var stream = new FileStream("demo.html", FileMode.Create, FileAccess.Write,
		//										  FileShare.None, 4096, useAsync: true);
		//		var utf8enc = new System.Text.UTF8Encoding();
		//		byte[] sb = utf8enc.GetBytes(s);
		//		await stream.WriteAsync(sb, 0, sb.Length).ConfigureAwait(false);
		//	} catch (Exception ex) {
		//		MessageBox.Show(this, ex.ToString(), ex.Message);
		//	}
		//}

		private async Task GetHtmlCodeAsync(string uri) {
			try {
				using Stream stream = await client.GetStreamAsync(uri).ConfigureAwait(false);
				using var fileStream = new FileStream("demo.html", FileMode.Create, FileAccess.Write,
													FileShare.None, 4096, useAsync: true);
				await stream.CopyToAsync(fileStream).ConfigureAwait(false);
			} catch (Exception ex) {
				MessageBox.Show(this, ex.ToString(), ex.Message);
			}
		}

		private async void Button_Click(object sender, RoutedEventArgs e) {
			string temp = null;
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
