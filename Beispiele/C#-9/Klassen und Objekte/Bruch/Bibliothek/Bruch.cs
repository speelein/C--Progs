using System;

namespace ZIMK.CSC {

    public class Bruch {
        int zaehler,            // wird automatisch mit 0 initialisiert
            nenner = 1;
        string etikett = "";    // die Ref.typ-Init. auf null wird ersetzt, siehe Text

        static int anzahl;

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

        public static int Anzahl {
            get {
                return anzahl;
            }
            private set {
                anzahl = value;
            }
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

        public void Kuerze() {
            // größten gemeinsamen Teiler mit dem Euklids Algorithmus bestimmen
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
            } else
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
            } else
                return false;
        }

        public static Bruch operator +(Bruch b1, Bruch b2) {
            Bruch temp = new Bruch(b1.zaehler * b2.nenner + b1.nenner * b2.zaehler,
                                   b1.nenner * b2.nenner,
                                   nameof(b1) + " + " + nameof(b2));
            temp.Kuerze();
            return temp;
        }

        public bool Frage() {
            try {
                Console.Write("Zähler: ");
                int z = Convert.ToInt32(Console.ReadLine());
                Console.Write("Nenner: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Zaehler = z;
                Nenner = n;
                return true;
            } catch {
                return false;
            }
        }

        public void Zeige() {
            string luecke = "  ";
            string glz;
            for (int i = 1; i <= etikett.Length; i++)
                luecke += " ";
            if (etikett.Length == 0)
                glz = "";
            else {
                glz = " = ";
                luecke += "   ";
            }
            Console.WriteLine($" {luecke}{zaehler}\n {etikett}{glz}-----\n {luecke}{nenner}\n");
        }

        public void DuplWerte(Bruch bc) {
            bc.Zaehler = zaehler;
            bc.Nenner = nenner;
        }

        public Bruch Klone() {
            return new Bruch(zaehler, nenner, etikett);
        }

        public static Bruch BenDef(string e) {
            Bruch b = new Bruch(0, 1, e);
            if (b.Frage()) {
                b.Kuerze();
                return b;
            } else
                return null;
        }
    }
}