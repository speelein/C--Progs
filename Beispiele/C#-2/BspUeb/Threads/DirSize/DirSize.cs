using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;

delegate void LabelUpdateDelegate(string s);

class DirSize : Form {
    Label ergebnis;
    Thread worker;
    TextBox eingabe;
    Button start, stop, ende;
    bool bValToRemove = false;

    public DirSize() {
	    Height = 200; Width = 400;
        Text = "DirSize";

        ergebnis = new Label();
        ergebnis.Width = 300;
        ergebnis.Left = 170; ergebnis.Top = 60;
        ergebnis.Text = "";
	    Controls.Add(ergebnis);

        Label info1 = new Label();
        Label info2 = new Label();
        info1.Width = 150; info2.Width = 150;
        info1.Left = 20; info1.Top = 30;
        info2.Left = 20; info2.Top = 60;
        info1.Text = "Zu untersuchender Ordner:";
        info2.Text = "Größe in MBytes:";
        Controls.Add(info1);
        Controls.Add(info2);
        
        eingabe = new TextBox();
        eingabe.Left = 170; eingabe.Top = 30; eingabe.Width = 200;
        eingabe.TextChanged += new EventHandler(EingabeOnTextChanged);
        Controls.Add(eingabe);

        start = new Button();
        start.Text = "Start";
        start.Left = 50; start.Top = 100;
        Controls.Add(start);

        stop = new Button();
        stop.Text = "Stop";
        stop.Left = 150; stop.Top = 100;
        stop.Enabled = false;
        Controls.Add(stop);

        ende = new Button();
        ende.Text = "Ende";
        ende.Left = 250; ende.Top = 100;
        Controls.Add(ende);

        EventHandler eh = new EventHandler(ButtonOnClick);
        start.Click += eh;
        stop.Click += eh;
        ende.Click += eh;

        AcceptButton = start;
    }

    void ButtonOnClick(object sender, EventArgs e) {
        if (sender == start) {
            if (!Directory.Exists(eingabe.Text)) {
                ergebnis.Text = "Ordner exisiert nicht";
                bValToRemove = true;
                return;
            }
            ProcessThreadCollection ptc = Process.GetCurrentProcess().Threads;
            Console.WriteLine("Vor dem Worker-Start, Anzahl der Threads: " + ptc.Count);
            worker = new Thread(new ThreadStart(this.WorkerMethod));
            worker.Start();
            ergebnis.Text = "Berechnung läuft ...";
            start.Enabled = false;
            stop.Enabled = true;
            ptc = Process.GetCurrentProcess().Threads;
            Console.WriteLine("Worker gestartet, Zustand: " + worker.ThreadState + ", Anzahl der Threads: " + ptc.Count);
        } else if (sender == stop) {
            worker.Abort();
            ergebnis.Text = "Berechnung gestoppt";
            bValToRemove = true;
            start.Enabled = true;
            stop.Enabled = false;
            ProcessThreadCollection ptc = Process.GetCurrentProcess().Threads;
            Console.WriteLine("Worker abgebrochen, Zustand: " + worker.ThreadState + ", Anzahl der Threads: " + ptc.Count);
        } else
            Environment.Exit(0);
    }

    void WorkerMethod() {
        String strSize = "Unbekannt";
        try {
            DirectoryInfo di = new DirectoryInfo(eingabe.Text);
            long Size = DirectorySize(di);
            strSize = String.Format("{0,-10:f2}", Size / 1048576.0);
        } catch (ThreadAbortException) {
        } catch (Exception e) {
            Console.WriteLine(e);
            strSize = "Berechnung gescheitert, siehe Konsole";
        }
        BeginInvoke(new LabelUpdateDelegate(LabelUpdater), strSize);
    }

    long DirectorySize(DirectoryInfo d) {
        long Size = 0;
        FileInfo[] fis = d.GetFiles();
        foreach (FileInfo fi in fis) {
            Size += fi.Length;
        }
        DirectoryInfo[] dis = d.GetDirectories();
        foreach (DirectoryInfo di in dis) {
            Size += DirectorySize(di);
        }
        return (Size);
    }

    void LabelUpdater(string s) {
        ergebnis.Text = s;
        bValToRemove = true;
        start.Enabled = true;
        stop.Enabled = false;
    }

    void EingabeOnTextChanged(object sender, EventArgs e) {
        if (bValToRemove) {
            ergebnis.Text = "";
            bValToRemove = false;
        }
    }

    static void Main() {
	    Application.Run(new DirSize());
    }
}
