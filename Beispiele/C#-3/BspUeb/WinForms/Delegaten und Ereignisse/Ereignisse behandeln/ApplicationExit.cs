using System;
using System.Windows.Forms;
class ApplicationExitDemo : Form {
	ApplicationExitDemo() {
		Text = "ApplicationExit-Ereignisbehandlung";
		Width = 340;
		Application.ApplicationExit += new EventHandler(this.ApplicationOnExit);
		//Application.ApplicationExit += ApplicationOnExit;
	}

	void ApplicationOnExit(object sender, EventArgs e) {
		MessageBox.Show("Vielen Dank für den Einsatz dieser Software!",
		 "WinForms-Einstieg");
	}

	static void Main() {
		Application.Run(new ApplicationExitDemo());
	}
}