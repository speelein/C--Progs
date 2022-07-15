using System;
class BruchRechnung {
	static void Main() {
		Aufgabe auf = new Aufgabe('*', 3, 4, 2, 3);
		auf.Pruefe();
		auf.NeueWerte('+', 1, 2, 2, 5);
		auf.Pruefe();
		Console.ReadLine();
	}
}