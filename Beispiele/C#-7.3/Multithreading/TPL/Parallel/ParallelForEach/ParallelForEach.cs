using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

class ParallelForEach {
	const int ANZ = 16;
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
        var iList = new List<int>();
        for (int i = 1; i <= 16; i++)
            iList.Add(i);
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        ParallelLoopResult plr = Parallel.ForEach(iList, SampleMean);
        stopWatch.Stop();
        Console.WriteLine("\nSchleife mit " + ANZ + " Umläufen fertig: " + plr.IsCompleted +
                            "\nBenötigte Zeit:\t" + stopWatch.Elapsed +
                            "\nAnzahl eingesetzter Threads:\t" + tids.Count);
    }
}