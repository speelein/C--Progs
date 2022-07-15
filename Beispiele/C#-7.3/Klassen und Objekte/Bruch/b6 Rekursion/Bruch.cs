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

    int GGTi(int a, int b) {
        int rest;
        do {
            rest = a % b;
            a = b;
            b = rest;
        } while (rest > 0);
        return a;
    }

    int GGTr(int a, int b) {
        int rest = a % b;
        if (rest == 0)
            return b;
        else
            return GGTr(b, rest);
    }

    public void Kuerze() {
        if (zaehler != 0) {
            int teiler = GGTi(Math.Abs(zaehler), Math.Abs(nenner));
            Zaehler /= teiler;
            Nenner /= teiler;
        } else
            Nenner = 1;
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
        } else
            return false;
    }

    public bool Frage() {
        try {
            Console.Write("Zähler: ");
            int z = Convert.ToInt32(Console.ReadLine());
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

    public void DuplWerte(Bruch bc) {
        bc.Zaehler = zaehler;
        bc.Nenner = nenner;
    }

    public Bruch Klone() {
        return new Bruch(zaehler, nenner, etikett);
    }
}
