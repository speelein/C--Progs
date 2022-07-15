using System;
class Prog {
	static void Main() {
		Figur[] fa = new Figur[2];
		fa[0] = new Kreis(50.0, 50.0, 5.0);
		fa[1] = new Rechteck(10.0, 10.0, 5.0, 5.0);
		fa[0].Skaliere(2.0);
		fa[1].Skaliere(2.0);
		double ges = 0.0;
		for (int i = 0;  i < fa.Length; i++) {
			Console.WriteLine("Fläche Figur {0}: {1,10:f2}\n", i, fa[i].Inhalt);
			ges += fa[i].Inhalt;
		}
		Console.WriteLine("Gesamtfläche:   {0,10:f2}",ges);
	}
}
