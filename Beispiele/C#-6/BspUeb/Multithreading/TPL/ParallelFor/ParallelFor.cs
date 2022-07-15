using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

class ParallelFor {
	const int ANZ = 100;
	const int SG = 10000000;
	static HashSet<int> tids = new HashSet<int>();

	static void SampleMean(int i) {
		Random zzg = new Random(i);
		double erg = 0.0;
		for (int j = 0; j < SG; j++)
			erg += zzg.NextDouble();
		Console.WriteLine("Stichprobenmittel " + (erg / SG) + " mit Startwert " + i +
							" berechnet von Thread " + Thread.CurrentThread.ManagedThreadId);

		lock (tids) { tids.Add(Thread.CurrentThread.ManagedThreadId); }
	}

	static void Main() {
		ParallelLoopResult plr = Parallel.For(1, ANZ, SampleMean);
		Console.WriteLine("\nSchleife mit "+ANZ+" Umläufen vollständig abgearbeitet: "+plr.IsCompleted+
			              "\nAnzahl eingesetzter Threads: " + tids.Count);
	}
}