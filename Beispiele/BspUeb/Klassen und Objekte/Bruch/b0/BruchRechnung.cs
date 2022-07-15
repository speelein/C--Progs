using System;

class BruchRechnung {
	static void Main() {
		Console.WriteLine("Kürzen von Brüchen\n------------------\n");
		Bruch b = new Bruch();
		b.Frage();
		b.Kuerze();
		b.Etikett = "Der gekürzte Bruch:";
		b.Zeige();
        Console.ReadLine();
	}
}
