using System;
using System.Collections.Generic;

readonly struct Punkt {
    public readonly double X, Y;
    public Punkt(double x, double y) {
        X = x; Y = y;
    }
    public void Deconstruct(out double x, out double y) {
        x = X;
        y = Y;
    }
}

class Positionsmuster {
    public static int Zone(Punkt punkt) =>
         punkt switch {
            var (x, y) when x < 0 && y > 0 => 1,
            var (x, y) when x > 0 && y > 0 => 2,
            (_, var y) when y < 0 => 3,
            (0, var y) when y > 0 => 4,
            (_, 0) => 5
        };

    static void Main() {
        var p1 = new Punkt(-2, 2);
        var p2 = new Punkt( 2, 2);
        var p3 = new Punkt(-2,-2);
        var p4 = new Punkt( 0, 2);
        var p5 = new Punkt(-2, 0);
        var pl = new List<Punkt> { p1, p2, p3, p4, p5 };
        for (int i = 0; i < pl.Count; i++)
           Console.WriteLine($"({pl[i].X,2},{pl[i].Y,2}): Zone {Zone(pl[i])}");
    }
}
