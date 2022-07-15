using System;
class Prog {
	static void Main() {
		Punkt p1 = new Punkt(1.0, 2.0),
		      p2 = new Punkt(2.0, 3.0);
		Console.WriteLine(p1.CompareTo(p2)); // Boxing
		//Console.WriteLine(p1.CompareTo(13)); // Laufzeitfehler
		Console.Read();
	}
}
