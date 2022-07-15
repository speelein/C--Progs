using System;
using System.Threading;

public delegate long[] Zumme(int anz);

class Prog {
	static Random zzg = new Random();

	static long[] RandomSums(int anz) {
		long[] erg = new long[anz];
		for (int i = 0; i < anz; i++) {
			for (int j = 0; j < 10000000; j++)
				erg[i] += zzg.Next(100);
		}
		return erg;
	}

	static void Main() {
		Console.WriteLine("Der Arbeitsdelegat soll per Poolthread 7 " +
			"Summen von Zufallszahlen ermitteln.\n");
		Zumme rs = new Zumme(RandomSums);
		IAsyncResult ar = rs.BeginInvoke(7, null, null);
		// Polling:
		int sek = 0;
		while (!ar.IsCompleted) {
			Console.WriteLine("Warte seit {0} Sekunden auf den Hintergrund-Thread", sek);
			Thread.Sleep(1000);
			sek++;
		}
		Console.WriteLine("\nReport der ermittelten Summen:");
		foreach (long zs in rs.EndInvoke(ar))
			Console.WriteLine(" " + zs);
		Console.ReadLine();
	}
}