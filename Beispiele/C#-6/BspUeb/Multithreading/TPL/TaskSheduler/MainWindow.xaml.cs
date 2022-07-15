using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskSheduler {
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
			return erg / SG;
		}

		public MainWindow() {
			InitializeComponent();
		}

		private void button_Click(object sender, RoutedEventArgs e) {
			label.Content = "";
			Task<double> task = Task.Factory.StartNew<double>(SampleMean);
			task.ContinueWith(t => { label.Content = t.Result.ToString(); }, uiTS);
		}
	}
}
