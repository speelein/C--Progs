using System;

public class Bruch {
    int zaehler,            // wird automatisch mit 0 initialisiert
        nenner = 1;
    string etikett = "";    // die Ref.typ-Init. auf null wird ersetzt, siehe Text

    static int anzahl;

    public static int Anzahl {
        get {
            return anzahl;
        }
        private set {
            anzahl = value;
        }
    }

    public static Bruch BenDef(string e) {
        Bruch b = new Bruch(0, 1, e);
        if (b.Frage()) {
            b.Kuerze();
            return b;
        }
        else
            return null;
    }

    public Bruch(int zpar, int npar, String epar) {
        Zaehler = zpar;
        Nenner = npar;
        Etikett = epar;
        Anzahl++;
    }

    public Bruch() {
        Anzahl++;
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
        // gr��ten gemeinsamen Teiler mit dem Euklids Algorithmus bestimmen
        // (performante Variante mit Modulo-Operator)
        if (Zaehler != 0) {
            int rest;
            int ggt = Math.Abs(zaehler);
            int divisor = Math.Abs(nenner);
            do {
                rest = ggt % divisor;
                ggt = divisor;
                divisor = rest;
            } while (rest > 0);
            Zaehler /= ggt;
            Nenner /= ggt;
        }
        else
            nenner = 1;
    }

    public void Addiere(Bruch b) {
        Zaehler = zaehler * b.nenner + b.zaehler * nenner;
        Nenner = nenner * b.nenner;
        Kuerze();
    }

    public bool Addiere(int zpar, int npar, bool autokurz) {
        if (npar != 0) {
            Zaehler = zaehler * npar + zpar * nenner;
            Nenner = nenner * npar;
            if (autokurz)
                Kuerze();
            return true;
        }
        else
            return false;
    }

    public static Bruch operator+(Bruch b1, Bruch b2) {
        Bruch temp = new Bruch(b1.zaehler * b2.nenner + b1.nenner * b2.zaehler, b1.nenner * b2.nenner, "");
        temp.Kuerze();
        return temp;
    }

    public void Multipliziere(Bruch b) {
        Zaehler = zaehler * b.zaehler;
        Nenner = nenner * b.nenner;
        Kuerze();
    }

    public static Bruch operator*(Bruch b1, Bruch b2) {
        Bruch temp = new Bruch(b1.zaehler * b2.zaehler, b1.nenner * b2.nenner, "");
        temp.Kuerze();
        return temp;
    }

    public bool Frage() {
        try {
            Console.Write("Zaehler: ");
            int z = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nenner : ");
            int n = Convert.ToInt32(Console.ReadLine());
            Zaehler = z;
            Nenner = n;
            return true;
        }
        catch {
            return false;
        }
    }

    public void Zeige() {
        string luecke = "";
        for (int i = 1; i <= Etikett.Length; i++)
            luecke = luecke + " ";
        Console.WriteLine(" {0}   {1}\n {2} -----\n {0}   {3}\n",
                          luecke, zaehler, etikett, nenner);
    }

    public void DuplWerte(Bruch bc) {
        bc.Zaehler = zaehler;
        bc.Nenner = nenner;
    }

    public Bruch Klone() {
        return new Bruch(zaehler, nenner, etikett);
    }
}