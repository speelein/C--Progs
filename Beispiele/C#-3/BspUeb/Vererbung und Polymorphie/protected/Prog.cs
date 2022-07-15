using System;
class Prog {
	static void Main() {
		Kreis krs = new Kreis(10.0, 10.0, 5.0);
//		krs.xpos = 77.7;				verboten
		krs.SetzePos(77.7, 99.4);	//  erlaubt
		Console.ReadLine();
	}
}
