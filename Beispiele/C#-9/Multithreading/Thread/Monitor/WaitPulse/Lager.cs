using System;
using System.Threading;

public class Lager {
	int bilanz;
	int anz;
	const int maxAnz = 20;
	const int startKap = 100;
	Object lockObject = new Object();
	System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("de-DE");

	public Lager(int start) {
		bilanz = start;
	}

	public bool Ergaenze(int add) {
		lock (lockObject) {
			if (anz < maxAnz) {
				bilanz += add;
				anz++;
				Rumoren();
				Console.WriteLine("Nr. {0,2}: {1,10} ergänzt  {2,3} um {3} Uhr. Stand: {4}",
								  anz, Thread.CurrentThread.Name, add, DateTime.Now.ToString("T", ci), bilanz);
				Monitor.Pulse(lockObject);
				return true;
			} else {
				Console.WriteLine("\nLieber " + Thread.CurrentThread.Name +
					", es ist Feierabend!");
				return false;
			}
		}
	}

	public bool Liefere(int sub) {
		lock (lockObject) {
			if (anz < maxAnz) {
				while (bilanz < sub) {
					Console.WriteLine("!!!!!!! {0,10} muss warten: "+
									"Keine {1, 3} Einheiten vorhanden um {2} Uhr.",
									Thread.CurrentThread.Name, sub, DateTime.Now.ToString("T", ci));
					Monitor.Wait(lockObject);
				}
				anz++;
				bilanz -= sub;
				Rumoren();
				Console.WriteLine("Nr. {0,2}: {1,10} entnimmt {2, 3} um {3} Uhr. Stand: {4}",
								  anz, Thread.CurrentThread.Name, sub, DateTime.Now.ToString("T", ci), bilanz);
				return true;
			} else {
				Console.WriteLine("\nLieber " + Thread.CurrentThread.Name +
					", es ist Feierabend!");
				return false;
			}
		}
	}

	void Rumoren() {
		double d;
		for (int i = 0; i < 40000; i++)
			d = i * i;
	}

	static void Main() {
		Lager lager = new Lager(startKap);
		Console.WriteLine("Das Lager ist offen (Bestand: {0})\n", startKap);
		Produzent pro = new Produzent(lager);
		Konsument kon = new Konsument(lager);
		Thread pt = new Thread(pro.Run);
		Thread kt = new Thread(kon.Run);
		pt.Name = "Produzent";
		kt.Name = "Konsument";
		pt.Start();
		kt.Start();
		Console.ReadLine();
	}
}
