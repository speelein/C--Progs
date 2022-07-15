using System;

readonly struct LKW {
    public double Gewicht { get; }
    public LKW(double gew) => Gewicht = gew;
}

class Relationsmuster {
    public static decimal Maut(LKW lkw) =>
        lkw.Gewicht switch {
            <= 1000 => 10.0m,
            <= 2000 => 18.5m,
            <= 7500 => 25.2m,
            _ => 30.8m
        };

    static void Main() {
        Console.WriteLine("Maut: " + Maut(new LKW(1500)));
        Console.WriteLine("Maut: " + Maut(new LKW(8000)));
    }
}
