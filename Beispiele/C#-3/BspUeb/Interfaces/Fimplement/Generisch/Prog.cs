using System;
using System.Collections.Generic;
class Prog {
	static void Main() {
		List<Figur> kl = new List<Figur>();
		kl.Add(new Kreis("A", 250.0, 50.0, 10.0));
		kl.Add(new Kreis("B", 150.0, 50.0, 20.0));
		kl.Add(new Kreis("C", 50.0, 50.0, 30.0));
		Console.WriteLine(kl[0].Name + " "
			+ kl[1].Name + " " + kl[2].Name);
		kl.Sort();
		Console.WriteLine(kl[0].Name + " "
			+ kl[1].Name + " " + kl[2].Name);
		Console.Read();
	}
}
