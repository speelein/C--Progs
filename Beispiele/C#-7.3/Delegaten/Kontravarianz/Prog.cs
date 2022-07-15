using System;

public delegate int Vergleich<in T>(T x, T y);

class Prog {
    static int FigurenVergleich(Figur f1, Figur f2) {
        if (f1.X < f2.X)
            return -1;
        else
            if (f1.X > f2.X)
            return 1;
        else return 0;
    }

    static Kreis KleinsterKreis(Kreis k1, Kreis k2, Vergleich<Kreis> vk) {
        return vk(k1, k2) <= 0 ? k1 : k2;
    }

    static void Main() {
        var k1 = new Kreis(2, 2, 1);
        var k2 = new Kreis(1, 4, 1);
        Vergleich<Figur> vf = FigurenVergleich;
        Console.WriteLine(KleinsterKreis(k1, k2, vf).X);
    }
}
