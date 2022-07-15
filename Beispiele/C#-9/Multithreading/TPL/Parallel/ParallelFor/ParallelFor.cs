using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

class ParallelFor {
	const int number = 16;
	const int sampleSize = 10_000_000;
	static HashSet<int> tids = new HashSet<int>();

	static void SampleMean(int i) {
		var zzg = new Random(i);
		double erg = 0.0;
		for (int j = 0; j < sampleSize; j++)
			erg += zzg.NextDouble();
		Console.WriteLine($"Mittelwert {(erg / sampleSize), 8:f5}  mit Index {i, 2} " +
		                  $"berechnet von Thread {Thread.CurrentThread.ManagedThreadId}");
		lock (tids) { tids.Add(Thread.CurrentThread.ManagedThreadId); }
	}

	static void Main() {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        ParallelLoopResult plr = Parallel.For(1, number, SampleMean);
        stopWatch.Stop();
        Console.WriteLine("\nParallelLoopResult fertiggestellt: " + plr.IsCompleted +
                          "\nBenötigte Zeit: " + stopWatch.Elapsed +
                          "\nAnzahl eingesetzter Threads: " + tids.Count);
    }
}