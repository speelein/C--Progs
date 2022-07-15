using System;
class BruchRechnung {
	static void Main() {
		Bruch b1 = new Bruch(1, 2, "b1 = ");
		b1.Zeige();
		Bruch b2 = b1.Klone();
		b2.Zeige();
	}
}
