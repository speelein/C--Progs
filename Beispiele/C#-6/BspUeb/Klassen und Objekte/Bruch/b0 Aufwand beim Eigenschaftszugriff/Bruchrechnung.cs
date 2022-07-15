using System;
class BruchRechnung {
	static void Main() {
		Console.WriteLine("Eigenschafts- versus Feldzugriff\n");
        Bruch b = new Bruch();

		int anz = 100000000;

		// Klasse DateTime laden, um den Aufwand aus der Zeitmessung heraus zu halten
		long zeit = DateTime.Now.Ticks;

		// Lesen Zähler
		Console.WriteLine("\n\nLesen, Zähler");
        zeit = DateTime.Now.Ticks;
        int z;
        for (int i = 1; i <= anz; i++)
            z = b.Zaehler;
        zeit = DateTime.Now.Ticks - zeit;
        Console.WriteLine("\nBenöt. Zeit für den Eigenschaftszugriff:\t" + zeit / 1.0e4 + " Millisek.");

        zeit = DateTime.Now.Ticks;
        for (int i = 1; i <= anz; i++)
            z = b.zaehler;
        zeit = DateTime.Now.Ticks - zeit;
        Console.WriteLine("\nBenöt. Zeit für den Feldzugriff:\t\t" + zeit / 1.0e4 + " Millisek.");

        // Schreiben Zähler
        Console.WriteLine("\n\nSchreiben, Zähler");
        zeit = DateTime.Now.Ticks;
		for (int i = 1; i <= anz; i++)
			b.Zaehler = i;
		zeit = DateTime.Now.Ticks - zeit;
		Console.WriteLine("\nBenöt. Zeit für den Eigenschaftszugriff:\t" + zeit / 1.0e4 + " Millisek.");

		zeit = DateTime.Now.Ticks;
		for (int i = 1; i <= anz; i++)
			b.zaehler = i;
		zeit = DateTime.Now.Ticks - zeit;
		Console.WriteLine("\nBenöt. Zeit für den Feldzugriff:\t\t" + zeit / 1.0e4 + " Millisek.");


        // Lesen Nenner
        Console.WriteLine("\n\n\n\nLesen, Nenner");
        zeit = DateTime.Now.Ticks;
        for (int i = 1; i <= anz; i++)
            z = b.Nenner;
        zeit = DateTime.Now.Ticks - zeit;
        Console.WriteLine("\nBenöt. Zeit für den Eigenschaftszugriff:\t" + zeit / 1.0e4 + " Millisek.");

        zeit = DateTime.Now.Ticks;
        for (int i = 1; i <= anz; i++)
            z = b.nenner;
        zeit = DateTime.Now.Ticks - zeit;
        Console.WriteLine("\nBenöt. Zeit für den Feldzugriff:\t\t" + zeit / 1.0e4 + " Millisek.");

        // Schreiben Nenner
        Console.WriteLine("\n\nSchreiben, Nenner");
        zeit = DateTime.Now.Ticks;
        for (int i = 1; i <= anz; i++)
            b.Nenner = i;
        zeit = DateTime.Now.Ticks - zeit;
        Console.WriteLine("\nBenöt. Zeit für den Eigenschaftszugriff:\t" + zeit / 1.0e4 + " Millisek.");

        zeit = DateTime.Now.Ticks;
        for (int i = 1; i <= anz; i++)
            b.nenner = i;
        zeit = DateTime.Now.Ticks - zeit;
        Console.WriteLine("\nBenöt. Zeit für den Feldzugriff:\t\t" + zeit / 1.0e4 + " Millisek.");


        Console.Write("\nEnter zum Beenden");
        Console.ReadLine();

	}
}
