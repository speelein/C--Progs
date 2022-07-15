using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace ApplicationExit {
	/// <summary>
	/// Interaktionslogik für "App.xaml"
	/// </summary>
	public partial class App : Application {
		private void Application_Exit(object sender, ExitEventArgs e) {
			MessageBox.Show("Vielen Dank für den Einsatz dieser Software!", "Application Exit");
		}
	}
}
