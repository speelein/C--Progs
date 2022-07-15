using System;
class Bruchrechnung {
	static void Main() {
		Bruch b1 = new Bruch(1, 2, "b1");
		Bruch b2 = new Bruch();
		b1.Zeige();
		b2.Zeige();

        // Objektinitialisierer
        Bruch b3 = new Bruch { Zaehler = 3, Nenner = 7, Etikett = "b3" };
        b3.Zeige();
    }
}
