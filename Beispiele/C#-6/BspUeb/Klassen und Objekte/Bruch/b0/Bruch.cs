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
	    // größten gemeinsamen Teiler mit dem Euklids Algorithmus bestimmen
        // (performante Variante mit Modulo-Operator)
	    if (zaehler != 0) {
            int rest;
            int ggt = Math.Abs(zaehler);
            int divisor = Math.Abs(nenner);
            do {
                rest = ggt % divisor;
                ggt = divisor;
                divisor = rest;
            } while (rest > 0);
            zaehler /= ggt;
            nenner /= ggt;
        } else
            nenner = 1;
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
                          luecke, this.zaehler, this.etikett, this.nenner);
	}
}
