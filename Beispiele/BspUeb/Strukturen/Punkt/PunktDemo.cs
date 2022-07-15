using System;

class PunktDemo {
	static void Main() {
		Punkt p1 = new Punkt(1, 2);
		Punkt p2 = new Punkt();
		Punkt p3 = p1;
		p1.X = 2;
		Console.WriteLine("p1 = "+p1.Inhalt+
		                  "\np2 = "+p2.Inhalt+
		                  "\np3 = "+p3.Inhalt);
		Console.WriteLine(2.GetType());
        Console.ReadLine();
	}
}
