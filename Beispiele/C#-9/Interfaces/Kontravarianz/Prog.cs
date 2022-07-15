using System;
using System.Collections.Generic;

class Prog {
	static void Main() {
        var listeK = new List<Kreis>();
        listeK.Add(new Kreis("A", 210.0, 50.0, 100.0));
        listeK.Add(new Kreis("B", 250.0, 100.0, 120.0));
        listeK.Add(new Kreis("C", 130.0, 110.0, 80.0));

        listeK.Sort();

        foreach (Kreis k in listeK)
            Console.WriteLine(k.X);
    }
}
