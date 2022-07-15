using System.Windows;

namespace HandleUnhandledException {
	/// <summary>
	/// Interaktionslogik für "App.xaml"
	/// </summary>
	public partial class App : Application {
		private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
			//MessageBox.Show("Wenden Sie sich bitte an den Support der Firma Quax");
			//e.Handled = true;
			//Application.Current.Shutdown();

			if (MessageBox.Show("Autsch! Es ist ein unerwartetes Problem aufgetreten." +
				"Soll die Anwendung trotzdem fortgesetzt werden?", "HandleUnhandledException", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
				e.Handled = true;
			else {
				e.Handled = true;
				Application.Current.Shutdown();
			}
		}
	}
}
