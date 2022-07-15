using System;

class Bruch {
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
		// größten gemeinsamen Teiler mit dem Euklidischen Algorithmus bestimmen
		if (zaehler != 0) {
			int ggt = 0;
			int az = Math.Abs(zaehler);
			int an = Math.Abs(nenner);
			do {
				if (az == an)
					ggt = az;
				else 
					if (az > an) 
						az = az - an;
					else
						an = an - az;
			} while (ggt == 0);
			
			zaehler /= ggt;
			nenner  /= ggt;
		}
	}

	public void Addiere(Bruch b) {
		zaehler = zaehler*b.nenner + b.zaehler*nenner;
		nenner = nenner*b.nenner;
		Kuerze();
	}

	public void Frage() {
		Console.Write("Zaehler: ");
		Zaehler = Convert.ToInt32(Console.ReadLine());
		Console.Write("Nenner : ");
		Nenner = Convert.ToInt32(Console.ReadLine());
	}
	
}

