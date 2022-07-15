using System;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncWaitDeadlock {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private async Task WaitAsync() {
			//await Task.Delay(1000).ConfigureAwait(false);
			await Task.Delay(1000);
		}

		private async void button_Click(object sender, RoutedEventArgs e) {
			Task task = WaitAsync();
			//task.Wait();
			await task;
			text.Text = "Ready";
		}
	}
}
