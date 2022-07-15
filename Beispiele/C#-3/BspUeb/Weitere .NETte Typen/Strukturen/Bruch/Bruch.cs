using System;

public struct Bruch {
	// Bei Strukturen darf eine Felddeklaration keine Initialisierung enthalten.
	int zaehler, nenner;
	string etikett;

	public Bruch(int zpar, int npar, String epar) {
		zaehler = zpar;
		nenner  = npar;
		etikett = epar;
	}

// Bei Strukturen ist der parameterfreie Konstruktor reserviert:
//	public Bruch() {}

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

	public void Addiere(int zpar, int npar, bool autokurz) {
		zaehler = zaehler*npar + zpar*nenner;
		nenner = nenner*npar;
		if (autokurz)
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
        string luecke = "", letikett;
        if (etikett != null) {
            letikett = etikett;
            for (int i = 1; i <= etikett.Length; i++)
                luecke = luecke + " ";
        } else
            letikett = "";
        Console.WriteLine(" {0}   {1}\n {2} -----\n {0}   {3}\n",
                          luecke, zaehler, letikett, nenner);
    }

}
