using System;

class PunktDemo {
	static void Main() {
		var p1 = new Punkt(1, 2);
		var p2 = new Punkt();
		var p3 = p1;
		Punkt.Bewegen(p2, 1, 1); // nutzlos
		p1.Bewegen(1, 0); // ohne Effekt auf p3
		Console.WriteLine("p1 = " + p1.Pos()+
						  "\np2 = " + p2.Pos() +
						  "\np3 = " + p3.Pos());
	}
}
