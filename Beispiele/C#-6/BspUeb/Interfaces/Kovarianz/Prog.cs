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
		var listeF = new List<Figur> { new Figur(1, 2), new Figur(3, 4) };
		var listeK = new List<Kreis> { new Kreis(2, 2, 1), new Kreis(3, 4, 1) };
		Console.WriteLine(SmallestX(listeF));
		Console.WriteLine(SmallestX(listeK));

		//// Kovarinaz-Macke bei Arrays 
		//object[] oarr = new String[] { "a", "b" };
		//oarr[0] = 13;
		//foreach (String s in oarr)
		//	Console.WriteLine(s.Length);
	}
}
