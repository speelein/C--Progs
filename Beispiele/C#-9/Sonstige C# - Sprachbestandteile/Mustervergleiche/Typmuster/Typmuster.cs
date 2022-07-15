using System;
using System.Collections;

struct Punkt {
    internal double X;
    internal double Y;
}

struct Rechteck {
    internal double Breite;
    internal double Hoehe;
}

struct Kreis {
    internal double Radius;
    internal Punkt Zentrum;
}

class Typmuster {
    static double Flaeche(object figur) {
        return figur switch {
            Rechteck r => r.Breite * r.Hoehe,
            Kreis k => Math.PI * k.Radius * k.Radius,
            _ => 0.0
        };
    }

    static void Main() {
        Rechteck r = new Rechteck() { Breite = 5, Hoehe = 4 };
        Kreis k = new Kreis() { Radius = 5 };
        ArrayList al = new ArrayList { r, k };
        double gesamt = 0.0;
        foreach (var e in al)
            gesamt += Flaeche(e);
        Console.WriteLine($"Gesamtfläche: {gesamt:f2}");

        k.Zentrum.X = 7; k.Zentrum.Y = 8;
        Console.WriteLine(k is {Radius:5, Zentrum: {X:7, Y:8}});
        Console.WriteLine(k is { Radius: 5, Zentrum: {X: var x, Y: var y}} && x==y);
    }
}
