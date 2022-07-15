using System;
class BruchRechnung {
	static void Main() {
		Bruch b1 = new Bruch(1, 2, "b1 = ");
		Bruch b2 = new Bruch();
		b1.Zeige();
		b2.Zeige();
        Console.ReadLine();
	}
}
