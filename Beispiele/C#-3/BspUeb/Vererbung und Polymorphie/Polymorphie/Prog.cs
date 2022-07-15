using System;
class Prog {
	static void Main() {
		Figur[] fa = new Figur[3];
		fa[0] = new Figur();
		fa[1] = new Kreis();
		for (int i = 0; i < 2; i++) {
			fa[i].Wo();
			if (fa[i] is Kreis)
				Console.WriteLine("Radius:         " + ((Kreis)fa[i]).Radius);
		}
		Console.Write("\nWollen Sie zum Abschluss noch eine" +
		 " Figur oder einen Kreis erleben?" +
		 "\nWählen Sie durch Abschicken von \"f\" oder \"k\": ");
		if (Console.ReadLine().ToUpper()[0] == 'F')
			fa[2] = new Figur();
		else
			fa[2] = new Kreis();
		fa[2].Wo();
		Console.ReadLine();
	}
}
