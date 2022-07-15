using System;
using System.Threading.Tasks;
using System.Windows;

namespace ExeptionFromAntecedentTask {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		const int sampleSize = 70000000;

		TaskScheduler uiTS = TaskScheduler.FromCurrentSynchronizationContext();

		static double SampleMean() {
			var zzg = new Random();
			double erg = 0.0;
			for (int j = 0; j < sampleSize; j++)
				erg += zzg.NextDouble();
            return erg / sampleSize;
		}

		public MainWindow() {
			InitializeComponent();
		}

        private void Button_Click(object sender, RoutedEventArgs e) {
            label.Content = "";
	        Task<double> task = Task.Factory.StartNew<double>(SampleMean);
            task.ContinueWith(t => { label.Content = t.Result.ToString(); }, uiTS);
        }
    }
}
