using System;

public class Bruch {
    int zaehler,			// zaehler wird automatisch mit 0 initialisiert
	    nenner = 1;
	string etikett = "";	// die Ref.typ-Init. auf null wird ersetzt, siehe Text

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

	public string Etikett {
		get {
			return etikett;
		}
		set {
			if (value.Length <= 40)
				etikett = value;
			else
				etikett = value.Substring(0, 40);
		}
	}

	public void Kuerze() {
		// gr��ten gemeinsamen Teiler mit dem Euklidischen Algorithmus bestimmen
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

	public bool Frage() {
		try {
			Console.Write("Zaehler: ");
			int z  = Convert.ToInt32(Console.ReadLine());
			Console.Write("Nenner : ");
			int n = Convert.ToInt32(Console.ReadLine());
			Zaehler = z;
			Nenner = n;
			return true;
		} catch {
			return false;
		}
	}
	
    public void Zeige() {
	    string luecke = "";
	    for (int i = 1; i <= etikett.Length; i++)
		    luecke = luecke + " ";
        Console.WriteLine(" {0}   {1}\n {2} -----\n {0}   {3}\n",
                          luecke, zaehler, etikett, nenner);
    }
}
