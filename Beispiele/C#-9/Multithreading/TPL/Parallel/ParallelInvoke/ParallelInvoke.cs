using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class ParallelInvoke {
	const int number = 16;
	const int sampleSize = 10_000_000;
    static HashSet<int> tids = new HashSet<int>();

    static void SampleMean() {
		var zzg = new Random();
		double erg = 0.0;
		for (int j = 0; j < sampleSize; j++)
			erg += zzg.NextDouble();
		Console.WriteLine("Stichprobenmittel " + (erg / sampleSize) + " berechnet von Thread " +
						  Thread.CurrentThread.ManagedThreadId);
        lock (tids) { tids.Add(Thread.CurrentThread.ManagedThreadId); }
    }

	static void Main() {
		var av = new Action[number];
		for (int i = 0; i < number; i++)
			av[i] = new Action(SampleMean);
        var stopWatch = new Stopwatch();
        stopWatch.Start();
		try {
			Parallel.Invoke(av);
		} catch (Exception e) {
			Console.WriteLine(e);
		}
		stopWatch.Stop();
        Console.WriteLine("\nBenötigte Zeit: " + stopWatch.Elapsed +
                          "\nAnzahl eingesetzter Threads: " + tids.Count);
	}
}
