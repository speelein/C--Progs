using System;
using System.Windows.Forms;
using System.Threading;

delegate void LabelUpdateDelegate(string s);

class ThreadingTimer : Form {
    Label anzeige;
    System.Threading.Timer tim;
    Random zzg;

    public ThreadingTimer() {
	    Height = 130; Width = 350;
        Text = "System.Threading.Timer";
	    anzeige = new Label();
        anzeige.Width = 300;
        anzeige.Left = 20; anzeige.Top = 20;
	    Controls.Add(anzeige);
        zzg = new Random();

        tim = new System.Threading.Timer(HintergrundAktion, null, 0, 1000);

        TextBox eingabe = new TextBox();
        eingabe.Left = 20; eingabe.Top = 50; eingabe.Width = 125;
        Controls.Add(eingabe);
    }

    void HintergrundAktion(object info) {
        // Hier Hintergrundaktivitäten einfügen, die in einem einem eigenen Thread
        // aus dem Threadpool ausgeführt werden sollen.
        long l = 0;
        for (int i = 0; i < 10000000; i++)
            l += zzg.Next(100);
        BeginInvoke(new LabelUpdateDelegate(LabelUpdater), l.ToString());
    }

    void LabelUpdater(string s) {
        anzeige.Text = "Aktuelle Zufallssumme: "+s+" berechnet um "+
            DateTime.Now.ToLongTimeString();
    }

    static void Main() {
	    Application.Run(new ThreadingTimer());
    }
}
