using System;
class Eratosthenes {
	static void Main() {
		const int maxKand = 1_000;
		bool[] prim;
		bool aufgabe;
		int grenze, basis, i;

		Console.WriteLine("Primzahlensuche mit dem Sieb des Eratosthenes\n");	
		while (true) {
			// Aufgabe holen
			do {
				do {
					aufgabe = true;
					try {
						Console.Write("Suchen bis (erlaubt: 3 bis "+maxKand+", Beenden mit 0): ");
						grenze = Convert.ToInt32(Console.ReadLine());
					} catch {
						Console.WriteLine("\aFalsche Eingabe!\n");
						grenze = 0;
						aufgabe = false;
					}
				} while (!aufgabe);
				if (grenze == 0) {
					Console.WriteLine("\nViele Dank fuer den Einsatz dieser Software!\n");
					return; //Beendet das Programm
				} else
                    if (grenze < 3 || grenze > maxKand) {
					    Console.WriteLine($"Eingabe < 3 oder > {maxKand}\n");
				}
			} while (grenze < 3 || grenze > maxKand);

			// Kandidaten-Array erzeugen und vorbereiten
			int maxBasis = (int) (Math.Sqrt(grenze) + 0.5);
			prim = new bool[grenze+1];
			for (i = 1; i <= grenze; i++)
				prim[i] = true;

			// Eratosthenes-Sieb				
			for (basis = 2; basis <= maxBasis; basis++)
				if (prim[basis])
					for (i = 2; i*basis <= grenze; i++)
						prim[i*basis] = false;

			// Ergebnis ausgeben
			Console.WriteLine("\nPrimzahlen von 1 bis "+grenze+":\n");
			for (i = 2; i <= grenze; i++)
				if (prim[i]) Console.Write(i + " ");
			Console.WriteLine("\n\nWeiter mit Enter");
            Console.ReadLine();
		}
	}
}