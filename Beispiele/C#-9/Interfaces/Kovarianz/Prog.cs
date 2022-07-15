using System;
using System.Collections.Generic;

class Prog {
    //static double SmallestX(List<Figur> li) {
    static double SmallestX(IEnumerable<Figur> li) {
        double smallestX = Double.MaxValue;
		foreach (Figur f in li)
			if (f.X < smallestX)
				smallestX = f.X;
		return smallestX;
	}

	static void Main() {
		var listeF = new List<Figur>();
		listeF.Add(new Figur("A", 210.0, 50.0));
		listeF.Add(new Figur("B", 250.0, 100.0));
		var listeK = new List<Kreis>();
		listeK.Add(new Kreis("A", 250.0, 50.0, 100.0));
		listeK.Add(new Kreis("B", 250.0, 100.0, 120.0));
		Console.WriteLine(SmallestX(listeF));
		Console.WriteLine(SmallestX(listeK));

        //// Kovarinaz-Macke bei Arrays 
        //object[] oarr = new String[] { "a", "b" };
        //oarr[0] = 13;
        //foreach (String s in oarr)
        //    Console.WriteLine(s.Length);
    }
}
