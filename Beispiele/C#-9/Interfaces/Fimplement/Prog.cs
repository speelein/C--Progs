using System;
using System.Collections.Generic;
class Prog {
	static void Main() {
		var lf = new List<Figur>();
		lf.Add(new Kreis("A", 250.0, 50.0, 10.0));
		lf.Add(new Kreis("B", 150.0, 50.0, 20.0));
		lf.Add(new Kreis("C", 50.0, 50.0, 30.0));
		foreach (var v in lf)
			Console.Write(v.Name + " ");
		Console.WriteLine();
		lf.Sort();
		foreach (var v in lf)
			Console.Write(v.Name + " ");
		Console.WriteLine();

		var lk = new List<Kreis>();
		lk.Add(new Kreis("A", 250.0, 50.0, 10.0));
		lk.Add(new Kreis("B", 150.0, 50.0, 20.0));
		lk.Add(new Kreis("C", 50.0, 50.0, 30.0));
		foreach (var v in lk)
			Console.Write(v.Name + " ");
		Console.WriteLine();
		lk.Sort();
		foreach (var v in lk)
			Console.Write(v.Name + " ");
	}
}
