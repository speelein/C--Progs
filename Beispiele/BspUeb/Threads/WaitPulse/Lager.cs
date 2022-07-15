using System;
using System.Threading;

public class Lager {
	int bilanz;
	int anz;
	const int MANZ = 20;
	const int STARTKAP = 100;
	
	public bool Offen() {
		lock(this) {
			if (anz < MANZ)
				return true;
			else {
				Console.WriteLine("\nLieber "+Thread.CurrentThread.Name+
					", es ist Feierabend!");
				return false;
			}
		}
	}

    public void Ergaenze(int add) {
        if (!Offen()) return;
        lock(this) {
	        bilanz += add;
	        anz++;
	        Console.WriteLine("Nr. "+anz+":\t"+Thread.CurrentThread.Name+
		        " ergänzt\t"+add+"\tum "+DateTime.Now.TimeOfDay+" Uhr. Stand: "+bilanz);
	        Monitor.Pulse(this);
        }
    }

    public void Liefere(int sub) {
	    if (!Offen()) return;
	    lock(this) {
		    while (bilanz < sub) {
			    Console.WriteLine(Thread.CurrentThread.Name+
				    " muss warten: Keine "+sub+" Einheiten vorhanden.");
			    Monitor.Wait(this);
		    }
		    bilanz -= sub;
		    anz++;
		    Console.WriteLine("Nr. "+anz+":\t"+Thread.CurrentThread.Name+
			    " entnimmt\t"+sub+"\tum "+DateTime.Now.TimeOfDay+" Uhr. Stand: "+bilanz);
	    }
    }

	public Lager(int start) {
		bilanz = start;
	}

	static void Main() {
		Lager lager = new Lager(STARTKAP);
		Console.WriteLine("Der Laden ist offen (Bestand: {0})\n", STARTKAP);
		Produzent pro = new Produzent(lager);
		Konsument kon = new Konsument(lager);
		Thread pt = new Thread(new ThreadStart(pro.Run));
		Thread kt = new Thread(new ThreadStart(kon.Run));
		pt.Name = "Produzent";
		kt.Name = "Konsument";
		pt.Start();
		kt.Start();
	}
}
