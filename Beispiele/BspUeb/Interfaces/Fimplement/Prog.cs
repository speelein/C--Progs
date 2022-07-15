using System;
class Prog {
	static void Main() {
		Kreis[] k = new Kreis[3];
		k[0] = new Kreis("A", 250, 50, 10);
		k[1] = new Kreis("B", 150, 50, 20);
		k[2] = new Kreis("C", 50, 50, 30);
		Console.WriteLine(k[0].name + " " 
			+ k[1].name + " " + k[2].name);
		Array.Sort(k);
		Console.WriteLine(k[0].name + " " 
			+ k[1].name + " " + k[2].name);
        Console.ReadLine();
	}
}
