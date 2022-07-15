using System;
using System.Collections.Generic;

public class PKW {
    public int Passagiere;
    public bool Elektromobil;
    public bool Zugelassen() => Passagiere >= 3 || Elektromobil;
}

class AkzeptIndivMobil {
    static void Main() {
        var p1 = new PKW { Passagiere = 1, Elektromobil = false};
        var p2 = new PKW { Passagiere = 3, Elektromobil = false };
        var p3 = new PKW { Passagiere = 2, Elektromobil = true };
        var lp = new List<PKW> { p1, p2, p3 };

        for (int i = 0; i < lp.Count; i++)
           Console.WriteLine($"({lp[i].Passagiere,2}, {lp[i].Elektromobil,5}) zugelassen: {lp[i].Zugelassen()}");
    }
}
