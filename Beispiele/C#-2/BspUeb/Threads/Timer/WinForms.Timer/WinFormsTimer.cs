using System;
using System.Windows.Forms;

class WinFormsTimer : Form {
    Label anzeige;
    Random zzg;

    public WinFormsTimer() {
	    Height = 130; Width = 350;
        Text = "System.Windows.Forms.Timer";
	    anzeige = new Label();
        anzeige.Width = 300;
        anzeige.Left = 20; anzeige.Top = 20;
	    Controls.Add(anzeige);
        zzg = new Random();

        Timer tim = new Timer();
        tim.Tick += new EventHandler(TimerAktion);
        tim.Interval = 1000;
        tim.Start();

        TextBox eingabe = new TextBox();
        eingabe.Left = 20; eingabe.Top = 50; eingabe.Width = 125;
        Controls.Add(eingabe);
    }

    void TimerAktion(Object myObject, EventArgs myEventArgs) {
        long l = 0;
        for (int i = 0; i < 10000000; i++)
            l += zzg.Next(100);
        anzeige.Text = "Aktuelle Zufallssumme: " + l.ToString() +
            " berechnet um " + DateTime.Now.ToLongTimeString();
    }

    static void Main() {
	    Application.Run(new WinFormsTimer());
    }
}
