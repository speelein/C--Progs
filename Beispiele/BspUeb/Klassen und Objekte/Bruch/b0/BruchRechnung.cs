using System;

class BruchRechnung {
	static void Main() {
		Console.WriteLine("K�rzen von Br�chen\n------------------\n");
		Bruch b = new Bruch();
		b.Frage();
		b.Kuerze();
		b.Etikett = "Der gek�rzte Bruch:";
		b.Zeige();
        Console.ReadLine();
	}
}
