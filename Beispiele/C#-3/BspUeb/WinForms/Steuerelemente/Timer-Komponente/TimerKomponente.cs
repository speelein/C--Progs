using System;
using System.Windows.Forms;

class TimerKomponente : Form {

	TimerKomponente() {
		RichTextBox editor = new RichTextBox();
		editor.Dock = DockStyle.Fill;
		Controls.Add(editor);

		Timer tim = new Timer();
		tim.Interval = 1000;
		tim.Tick += new EventHandler(TimerOnTick);
		tim.Start();
	}

	void TimerOnTick(object sender, EventArgs e) {
		Text = DateTime.Now.ToLongTimeString();
	}

	[STAThread]
	static void Main() {
		Application.Run(new TimerKomponente());
	}
}