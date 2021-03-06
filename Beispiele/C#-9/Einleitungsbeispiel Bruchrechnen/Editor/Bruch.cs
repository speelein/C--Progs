using System;

public class Bruch {
	int zaehler,	// wird automatisch mit 0 initialisiert
	    nenner = 1;

	public int Zaehler {
		get {
			return zaehler;
		}
		set {
			zaehler = value;
		}
	}

	public int Nenner {
		get {
			return nenner;
		}
		set {
			if (value != 0)
				nenner = value;
		}
	}

	public void Zeige() {
		Console.WriteLine("   {0}\n  -----\n   {1}\n", zaehler, nenner);
	}

	public void Kuerze() {
		// gr??ten gemeinsamen Teiler mit dem Euklidischen Algorithmus bestimmen
		if (zaehler != 0) {
			int az = Math.Abs(zaehler);
			int an = Math.Abs(nenner);
			while (az != an)
				if (az > an)
					az = az - an;
				else
					an = an - az;
			zaehler = zaehler / az;
			nenner  = nenner / az;
		} else
			nenner = 1;
	}

	public void Addiere(Bruch b) {
		zaehler = zaehler*b.nenner + b.zaehler*nenner;
		nenner = nenner*b.nenner;
		Kuerze();
	}

	public void Frage() {
		Console.Write("Z?hler: ");
        zaehler = Convert.ToInt32(Console.ReadLine());
		Console.Write("Nenner: ");
		Nenner = Convert.ToInt32(Console.ReadLine());
	}
}

