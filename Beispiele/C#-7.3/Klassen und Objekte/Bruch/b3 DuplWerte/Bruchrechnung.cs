using System;
class Bruchrechnung {
	static void Main() {
		Bruch b1 = new Bruch(1, 2, "b1 = ");
		Bruch b2 = new Bruch(5, 6, "b2 = ");

		b1.Zeige();
		b2.Zeige();
		b1.DuplWerte(b2);
		Console.WriteLine("Nach DuplWerte():\n");
		b2.Zeige();
		Console.ReadLine();
	}
}
