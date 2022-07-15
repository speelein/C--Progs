using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class ParallelInvoke {
	const int ANZ = 16;
	const int SG = 10_000_000;
    static HashSet<int> tids = new HashSet<int>();

    static void SampleMean() {
		var zzg = new Random();
		double erg = 0.0;
		for (int j = 0; j < SG; j++)
			erg += zzg.NextDouble();
		Console.WriteLine("Stichprobenmittel " + (erg / SG) + " berechnet von Thread " +
						  Thread.CurrentThread.ManagedThreadId);
        lock (tids) { tids.Add(Thread.CurrentThread.ManagedThreadId); }
    }

	static void Main() {
		var av = new Action[ANZ];
		for (int i = 0; i < ANZ; i++)
			av[i] = new Action(SampleMean);
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        Parallel.Invoke(av);
        stopWatch.Stop();
        Console.WriteLine("\nBenötigte Zeit: " + stopWatch.Elapsed +
                          "\nAnzahl eingesetzter Threads: " + tids.Count);
	}
}
