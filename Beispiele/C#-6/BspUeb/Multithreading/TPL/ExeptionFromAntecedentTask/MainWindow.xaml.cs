using System;
using System.Threading.Tasks;
using System.Windows;

namespace ExeptionFromAntecedentTask {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		const int SG = 70000000;

		TaskScheduler uiTS = TaskScheduler.FromCurrentSynchronizationContext();

		static double SampleMean() {
			var zzg = new Random();
			double erg = 0.0;
			for (int j = 0; j < SG; j++)
				erg += zzg.NextDouble();
			throw new Exception("Fehler in SampleMean");
			return erg / SG;
		}

		public MainWindow() {
			InitializeComponent();
		}

		private void button_Click(object sender, RoutedEventArgs e) {
			label.Content = "";
			Task<double> task = Task.Factory.StartNew<double>(SampleMean);

			//// Ausnahme wird ignoriert.
			//task.ContinueWith(t => { label.Content = t.Result.ToString(); }, uiTS);

			//// Untersuchung mit IsFaulted 
			//task.ContinueWith(t => {
			//	if (t.IsFaulted)
			//		label.Content = t.Exception.InnerException.Message;
			//	else
			//		label.Content = t.Result.ToString();
			//}, uiTS);

			// Fortsetzungsaufgabe nur nach Ausnahmefehler
			//task.ContinueWith(t => { label.Content = t.Exception.InnerException.Message; },
			//					new System.Threading.CancellationToken(),
			//					TaskContinuationOptions.OnlyOnFaulted, uiTS);

			// GetAwaiter() aus .NET 4.5
			var awaiter	= task.GetAwaiter();
			awaiter.OnCompleted(() => {
				try {
					label.Content = awaiter.GetResult().ToString();
				} catch (Exception ex) {
					label.Content = ex.Message;
				}
			});
		}
	}
}
