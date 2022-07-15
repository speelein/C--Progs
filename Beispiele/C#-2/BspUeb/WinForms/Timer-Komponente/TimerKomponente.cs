using System;
using System.Windows.Forms;
using System.Drawing;

class TimerKomponente : Form {
	Label lbTime;

	public TimerKomponente() {
		Height = 100; Width = 225;
		Text = "Timer-Komponente";

		lbTime = new Label();
		lbTime.Left = 65; lbTime.Top = 20;
		lbTime.Parent = this;
		lbTime.Font = new Font("Arial", 15);

		Timer tim = new Timer();
		tim.Interval = 1000;
		tim.Tick += new EventHandler(TimerOnTick);
		tim.Start();
	}

	void TimerOnTick(object sender, EventArgs e) {
		lbTime.Text = DateTime.Now.ToLongTimeString();
	}

	static void Main() {
		Application.Run(new TimerKomponente());
	}
}