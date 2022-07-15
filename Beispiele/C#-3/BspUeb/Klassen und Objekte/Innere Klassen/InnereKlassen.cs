using System;

class Familie {
    string name;
    Tochter t;
    Sohn s;

    public Familie(string name_, string nato, int alto, string naso, int also) {
        name = name_;
        t = new Tochter(this, nato, alto);
        s = new Sohn(this, naso, also);
    }

    public void Info() {
        Console.WriteLine("Die Kinder von Familie {0}:\n", name);
        t.Info();
        s.Info();
    }

    static void Main() {
        Familie f = new Familie("Müller", "Lea", 7, "Theo", 4);
        f.Info();
        Console.ReadLine();
    }

    class Tochter {
        Familie f;
        string name;
        int alter;

        public Tochter(Familie f_, string name_, int alt_) {
            f = f_;
            name = name_;
            alter = alt_;
        }

        public void Info() {
            Console.WriteLine("  Ich bin die {0}-jährige Tochter {1} von Familie {2}.",
                         alter, name, f.name);
        }
    }

    class Sohn {
        Familie f;
        string name;
        int alter;

        public Sohn(Familie f_, string name_, int alt_) {
            f = f_;
            name = name_;
            alter = alt_;
        }

        public void Info() {
            Console.WriteLine("  Ich bin der {0}-jährige Sohn {1} von Familie {2}.",
                         alter, name, f.name);
        }
    }
}
