using System;
using System.Collections.Generic;

class Prog {
	static void Main() {
        var listeK = new List<Kreis> { new Kreis(3, 5, 1), new Kreis(1, 4, 1) };
        listeK.Sort();

        foreach (Kreis k in listeK)
            Console.WriteLine(k.X);
    }
}
