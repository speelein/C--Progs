using System;
using System.Threading;

public delegate double[] MakeDoubleArray(int anz);

class Prog {
	static Random zzg = new Random();

	static double[] RandomSums(int anz) {
		var erg = new double[anz];
		for (int i = 0; i < anz; i++) {
			for (int j = 0; j < 10_000_000; j++)
				erg[i] += zzg.Next(100);
		}
		return erg;
	}

	static void Main() {
		Console.WriteLine("Der Arbeitsdelegat soll per Poolthread 10 " +
			"Summen von Zufallszahlen ermitteln.\n");
		var rs = new MakeDoubleArray(RandomSums);
		IAsyncResult ar = rs.BeginInvoke(10, null, null);

		// Polling:
		int sek = 0;
		// Per IsCompleted()
		while (!ar.IsCompleted) {
			Console.WriteLine("Warte seit {0} Sekunden auf den Hintergrund-Thread", sek++);
			Thread.Sleep(1000);
		}
		// Per AsyncWaitHandle
		//while (!ar.AsyncWaitHandle.WaitOne(1000))
		//    Console.WriteLine("Warte seit {0} Sekunden auf den Hintergrund-Thread", ++sek);

		Console.WriteLine("\nReport der ermittelten Summen:");
		foreach (double zs in rs.EndInvoke(ar))
			Console.WriteLine(" " + zs);
	}
}