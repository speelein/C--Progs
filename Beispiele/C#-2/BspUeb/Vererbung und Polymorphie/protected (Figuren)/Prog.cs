using System;
class Prog {
	static void Main() {
		Kreis krs = new Kreis(10, 10, 5);
//		krs.xpos = 77;				verboten
		krs.SetzePos(77, 99);	//  erlaubt
        Console.ReadLine();
	}
}
