using System;
using System.Collections.Generic;
class Prog {
	static void Main() {
		var lf = new List<Figur>();
		lf.Add(new Kreis("A", 250.0, 50.0, 10.0));
		lf.Add(new Kreis("B", 150.0, 50.0, 20.0));
		lf.Add(new Kreis("C", 50.0, 50.0, 30.0));
		Console.WriteLine(lf[0].Name + " " + lf[1].Name + " " + lf[2].Name);
		lf.Sort();
		Console.WriteLine(lf[0].Name + " " + lf[1].Name + " " + lf[2].Name);
		Console.WriteLine();

		var lk = new List<Kreis>();
		lk.Add(new Kreis("A", 250.0, 50.0, 10.0));
		lk.Add(new Kreis("B", 150.0, 50.0, 20.0));
		lk.Add(new Kreis("C", 50.0, 50.0, 30.0));
		Console.WriteLine(lk[0].Name + " " + lk[1].Name + " " + lk[2].Name);
		lk.Sort();
		Console.WriteLine(lk[0].Name + " " + lk[1].Name + " " + lk[2].Name);
	}
}
