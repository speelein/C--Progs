using System;
using System.Windows.Forms;
class ApplicationExitDemo : Form {
	void ApplicationOnExit(object sender, EventArgs e) {
		MessageBox.Show("Vielen Dank für den Einsatz dieser Software!",
		 "WinForms-Einstieg");
	}
	static void Main() {
		ApplicationExitDemo hf = new ApplicationExitDemo();
		hf.Text = "ApplicationExit-Behandlung";
		Application.ApplicationExit += new EventHandler(hf.ApplicationOnExit);
		Application.Run(hf);
	}
}
