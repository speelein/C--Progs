using System;
using System.Collections.Generic;
class Prog {
	static void Main() {
		List<Figur> lf = new List<Figur>();
			lf.Add(new Figur("A", 250.0, 50.0));
			lf.Add(new Figur("B", 150.0, 50.0));
			lf.Add(new Figur("C", 50.0, 50.0));
		Console.WriteLine("Figuren:");
		Console.WriteLine(lf[0].Name + " "
			+ lf[1].Name + " " + lf[2].Name);
		lf.Sort();
		Console.WriteLine(lf[0].Name + " "
			+ lf[1].Name + " " + lf[2].Name);

		List<Kreis> kl = new List<Kreis>();
		kl.Add(new Kreis("A", 250.0, 50.0, 10.0));
		kl.Add(new Kreis("B", 150.0, 50.0, 20.0));
		kl.Add(new Kreis("C", 50.0, 50.0, 30.0));
		Console.WriteLine("\nKreise:");
		Console.WriteLine(kl[0].Name + " "
			+ kl[1].Name + " " + kl[2].Name);
		kl.Sort();
		Console.WriteLine(kl[0].Name + " "
			+ kl[1].Name + " " + kl[2].Name);
		Console.Read();

		//InvalidCastException:
		//IComparable[] ic = new IComparable[2];
		//ic[0] = new Figur("F", 100, 100);
		//ic[1] = 13;
		//Array.Sort(ic);
	}
}
