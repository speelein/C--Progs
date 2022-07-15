using System;
using System.Threading;

public class Lager {
	int bilanz;
	int anz;
	const int MANZ = 20;
	const int STARTKAP = 100;
	
	public bool Offen() {
		if (anz < MANZ)
			return true;
		else {
			Console.WriteLine("\nLieber "+Thread.CurrentThread.Name+
				", es ist Feierabend!");
			return false;
		}
	}

	public void Ergaenze(int add) {
		if (!Offen()) return;
		bilanz += add;
		anz++;
        rumoren();
        Console.WriteLine("Nr. "+anz+":\t"+Thread.CurrentThread.Name+
			" ergänzt\t"+add+"\tum "+DateTime.Now.TimeOfDay+" Uhr. Stand: "+bilanz);
	}

	public void Liefere(int sub) {
		if (!Offen()) return;
		bilanz -= sub;
		anz++;
        rumoren();
		Console.WriteLine("Nr. "+anz+":\t"+Thread.CurrentThread.Name+
			" entnimmt\t"+sub+"\tum "+DateTime.Now.TimeOfDay+" Uhr. Stand: "+bilanz);
	}

    void rumoren() {
        double d;
        for (int i = 0; i < 40000; i++)
            d = i * i;
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
