using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace DirSize {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {

		bool bValToRemove;
		CancellationTokenSource cts;
		CancellationToken ct;
		Task<string> ts;

		public MainWindow() {
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e) {
			Keyboard.Focus(eingabe);
		}

		string DirSize(Object dirp) {
			string dir = (string)dirp;
			var di = new DirectoryInfo(dir);
			long Size = DirSizeRec(di, ct);
			return string.Format("{0,-10:f2}", Size / 1048576.0);
		}

		long DirSizeRec(DirectoryInfo d, CancellationToken ct) {
			long size = 0;
			FileInfo[] fis = d.GetFiles();
			foreach (FileInfo fi in fis) {
				size += fi.Length;
			}
			DirectoryInfo[] dis = d.GetDirectories();
			foreach (DirectoryInfo di in dis) {
				if (ct.IsCancellationRequested) {
					ct.ThrowIfCancellationRequested();
				}
				else
					size += DirSizeRec(di, ct);
			}
			return size;
		}

		void UpdateLabel(string s) {
			ergebnis.Content = s;
			bValToRemove = true;
			start.IsEnabled = true;
		}

		private async void start_Click(object sender, RoutedEventArgs e) {
			if (!Directory.Exists(eingabe.Text)) {
				ergebnis.Content = "Ordner exisiert nicht";
				bValToRemove = true;
				return;
			}
			try {
				ergebnis.Content = "Berechnung läuft ...";
				start.IsEnabled = false;
				stop.IsEnabled = true;
				cts = new CancellationTokenSource();
				ct = cts.Token;
				ts = Task.Factory.StartNew<string>(DirSize, eingabe.Text, ct);
				string s = await ts;
				UpdateLabel(s);
			} catch (OperationCanceledException) {
				ergebnis.Content = "Abgebrochen";
			} catch (Exception ex) {
				ergebnis.Content = "";
				MessageBox.Show(ex.Message);
			} finally {
				start.IsEnabled = true;
			}
		}

		private void cancel_Click(object sender, RoutedEventArgs e) {
			if (ts != null && ts.Status == TaskStatus.Running) {
				cts.Cancel();
				ergebnis.Content = "Abbruch angefordert";
				bValToRemove = true;
				start.IsEnabled = true;
			}
		}

		private void stop_Click(object sender, RoutedEventArgs e) {
			Application.Current.Shutdown();
		}

		private void eingabe_TextChanged(object sender, TextChangedEventArgs e) {
			if (bValToRemove) {
				ergebnis.Content = "";
				bValToRemove = false;
			}
		}
	}
}
