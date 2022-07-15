using System;

public delegate T Funk<out T>();

class Prog {
    static void Where(Funk<Figur> figur) {
	    Console.WriteLine($"({figur().X}, {figur().Y})");
    }

    static void Main() {
        Funk<Kreis> fk = delegate () {
            Random zzg = new Random();
            return new Kreis(zzg.Next(5), zzg.Next(5), zzg.Next(3));
        };
        Where(fk);
    }
}
