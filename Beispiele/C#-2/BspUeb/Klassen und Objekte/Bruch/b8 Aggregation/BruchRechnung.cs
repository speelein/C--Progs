using System;
class BruchRechnung {
	static void Main() {
		Aufgabe auf = new Aufgabe('+', 1, 2, 2, 5);
		auf.Frage();
		Console.WriteLine();
		if (auf.Korrekt)
			Console.WriteLine(" Gut!");
		else
			auf.Zeige(2);
		auf.NeueWerte('*', 3, 4, 2, 3);
		auf.Frage();
		Console.WriteLine();
		if (auf.Korrekt)
			Console.WriteLine(" Gut!");
		else
			auf.Zeige(2);
        Console.ReadLine();
	}
}
