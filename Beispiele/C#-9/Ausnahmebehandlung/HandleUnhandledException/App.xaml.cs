using System.Windows;

namespace HandleUnhandledException {
	/// <summary>
	/// Interaktionslogik für "App.xaml"
	/// </summary>
	public partial class App : Application {
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
            //MessageBox.Show("Die Anwendung muss wegen des folgenden Problems beendet werden:\n\n" +
            //                e.Exception.Message +
            //                "\n\nWenden Sie sich bitte an den Support der Firma Quax"); ;
            //e.Handled = true;
            //Application.Current.Shutdown();

            e.Handled = true;
            if (MessageBox.Show("Es ist ein Problem aufgetreten:\n\n" + e.Exception.Message +
                                "\n\nSoll die Anwendung trotzdem fortgesetzt werden?",
                                "HandleUnhandledException", MessageBoxButton.YesNo) == MessageBoxResult.No)
                Application.Current.Shutdown();
        }
	}
}
