using System;

public class Bruch {
	int zaehler,			// wird automatisch mit 0 initialisiert
	    nenner = 1;
	string etikett = "";	// die Ref.typ-Init. auf null wird ersetzt, siehe Text

	public static int anzahl;
	static readonly int zaehlerVoreinst;
	static readonly int nennerVoreinst;

	public static int Anzahl {
		get {
			return anzahl;
		}
	}

    public static Bruch BenDef(string e) {
        Bruch b = new Bruch(0, 1, e);
        if (b.Frage()) {
            b.Kuerze();
            return b;
        } else
            return null;
    }

	static Bruch() {
		Random zuf = new Random();
		zaehlerVoreinst = zuf.Next(1,7);
		nennerVoreinst = zuf.Next(zaehlerVoreinst,9);
	}

	public Bruch(int zpar, int npar, String epar) {
		zaehler = zpar;
		Nenner  = npar;
		etikett = epar;
		anzahl++;
	}

	public Bruch() {
		zaehler = zaehlerVoreinst;
		nenner = nennerVoreinst;
		anzahl++;
	}

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
		// grten gemeinsamen Teiler mit dem Euklidischen Algorithmus bestimmen
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

	public void Addiere(int zpar, int npar, bool autokurz) {
		zaehler = zaehler*npar + zpar*nenner;
		nenner = nenner*npar;
		if (autokurz)
			Kuerze();
	}

	public static Bruch operator+ (Bruch b1, Bruch b2) {
		Bruch temp = new Bruch(b1.Zaehler * b2.Nenner + b1.Nenner * b2.Zaehler, b1.Nenner * b2.Nenner, "");
		temp.Kuerze();
		return temp;
	}

	public void Multipliziere(Bruch b) {
		zaehler = zaehler*b.zaehler;
		nenner = nenner*b.nenner;
		Kuerze();
	}

	public static Bruch operator* (Bruch b1, Bruch b2) {
		Bruch temp = new Bruch(b1.Zaehler * b2.Zaehler, b1.Nenner * b2.Nenner, "");
		temp.Kuerze();
		return temp;
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
		for (int i=1; i <= etikett.Length; i++)
			luecke = luecke + " ";
		Console.WriteLine(" {0}   {1}\n {2} -----\n {0}   {3}\n",
		                  luecke, zaehler, etikett, nenner);
	}

	public void DuplWerte(Bruch bc) {
		bc.zaehler = zaehler;
		bc.nenner = nenner;
	}
	public Bruch Klone() {
		return new Bruch(zaehler, nenner, etikett);
	}
}
