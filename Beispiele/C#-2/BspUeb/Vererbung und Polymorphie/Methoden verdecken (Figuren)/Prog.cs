using System;
class Prog {
	static void Main() {
		Figur  f = new Figur(10, 20);
		f.Wo();
		Kreis  k = new Kreis(50, 50, 10);
		k.Wo();
        Console.ReadLine();
	}
}
