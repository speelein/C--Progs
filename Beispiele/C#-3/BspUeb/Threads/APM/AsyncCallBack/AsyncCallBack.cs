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

	static void Report(IAsyncResult ar) {
		Zumme z = (Zumme)ar.AsyncState;
		Console.WriteLine("Report der ermittelten Summen:");
		foreach (long zs in z.EndInvoke(ar))
			Console.WriteLine(" "+zs);
	}

	static void Main() {
		Zumme rs = new Zumme(RandomSums);
		rs.BeginInvoke(3, new AsyncCallback(Report), rs);
		Console.WriteLine("Der Arbeitsdelegat soll per Poolthread 3 " +
			"Summen von Zufallszahlen ermitteln.\n");
		Console.WriteLine("Der primäre Thread schläft 5 Sekunden.\n");
		Thread.Sleep(5000);
		Console.WriteLine("\nDer primäre Thread ist aufgewacht.\n");
		Console.ReadLine();
	}
}