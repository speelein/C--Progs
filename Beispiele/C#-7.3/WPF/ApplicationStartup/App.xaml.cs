using System;
using System.Windows;

namespace ApplicationStartup {
	public partial class App : Application {
		private void Application_Startup(object sender, StartupEventArgs e) {
            String[] args = Environment.GetCommandLineArgs();
            for (int i = 1; i< args.Length; i++) 
                MessageBox.Show("Argument "+i+": "+ args[i], "Application Startup");
		}
	}
}
