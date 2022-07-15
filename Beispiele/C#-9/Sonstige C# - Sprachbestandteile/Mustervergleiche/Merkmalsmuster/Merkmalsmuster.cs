using System;
using System.Collections;

class PKW {
    public int Passagiere;
    public bool GeradeNummer;
}

class LKW {
    public double Gewicht;
}

class Merkmalsmuster {
    static bool Zugelassen(object obj) =>
        obj switch {
            PKW { Passagiere: 1, GeradeNummer: true } => false,
            PKW { GeradeNummer: true } => true,
            PKW { GeradeNummer: false } => false,
            LKW lkw => lkw.Gewicht <= 7.5,
            _ => true
        };

    static void Main() {
        var p1 = new PKW { Passagiere = 1, GeradeNummer = true};
        var p2 = new PKW { Passagiere = 3, GeradeNummer = true};
        var p3 = new PKW { Passagiere = 4, GeradeNummer = false };
        var l1 = new LKW { Gewicht = 7 };
        var l2 = new LKW { Gewicht = 12 };
        var la = new ArrayList { p1, p2, p3, l1, l2 };
        for (int i = 0; i < la.Count; i++)
           Console.WriteLine($"Nr.: {i,2}, Zugelassen: {Zugelassen(la[i])}");
    }
}
