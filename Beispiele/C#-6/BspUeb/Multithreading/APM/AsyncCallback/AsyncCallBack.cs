using System;
using System.Threading;

public delegate double[] Zumme(int anz);

class Prog {
	static Random zzg = new Random();

	static double[] RandomSums(int anz) {
		double[] erg = new double[anz];
		for (int i = 0; i < anz; i++) {
			for (int j = 0; j < 10000000; j++)
				erg[i] += zzg.Next(100);
		}
		return erg;
	}

	static void Report(IAsyncResult ar) {
		Zumme z = (Zumme)ar.AsyncState;
		Console.WriteLine("Report der ermittelten Summen:");
		double[] da = z.EndInvoke(ar);
		foreach (double zs in da)
			Console.WriteLine(" "+zs);
	}

	static void Main() {
		Zumme rs = new Zumme(RandomSums);
		rs.BeginInvoke(3, new AsyncCallback(Report), rs);

		Console.WriteLine("Der Arbeitsdelegat soll per Pool-Thread 3 " +
			"Summen von Zufallszahlen ermitteln.\n");
		Console.WriteLine("Der prim?re Thread schl?ft 5 Sekunden.\n");
		Thread.Sleep(5000);
		Console.WriteLine("\nDer prim?re Thread ist aufgewacht.\n");
	}
}