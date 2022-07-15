using System;
class Lotto {
	static void Main() {
		int[] ziehung = new int[6];
		int i, j, temp;
		bool verbraucht;

		Random zzg = new Random();

		//Unverbrauchte Lottozahlen suchen
		for (i = 0; i < 6; i++) {
			do {
				temp = zzg.Next(49)+1;
				verbraucht = false;
				for (j = 0; j < i; j++)
					if(temp == ziehung[j]) {
						verbraucht = true;
						break;
					}
			} while (verbraucht);
			ziehung[i] = temp;
		}

		//Sortieren
		Array.Sort(ziehung);

		// Ausgabe
		Console.WriteLine("Die Lottozahlen vom Mittwoch:");
		for (i = 0; i < 6; i++)
			Console.Write(" " + ziehung[i]);
		Console.WriteLine("\n\nBeenden mit Enter");
        Console.ReadLine();
	}
}
