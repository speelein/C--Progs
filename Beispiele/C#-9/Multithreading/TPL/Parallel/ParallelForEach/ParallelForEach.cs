using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

class ParallelForEach {
	const int number = 16;
	const int sampleSize = 10_000_000;
	static HashSet<int> tids = new HashSet<int>();

	static void SampleMean(int i) {
		var zzg = new Random(i);
		double erg = 0.0;
		for (int j = 0; j < sampleSize; j++)
			erg += zzg.NextDouble();
        Console.WriteLine($"Mittelwert {(erg / sampleSize),8:f5} mit Index {i,2} " +
                          $"berechnet von Thread {Thread.CurrentThread.ManagedThreadId}");

        lock (tids) { tids.Add(Thread.CurrentThread.ManagedThreadId); }
	}

    static void Main() {
        var iList = new List<int>();
        for (int i = 1; i <= number; i++)
            iList.Add(i);
        var stopWatch = new Stopwatch();
        try {
            stopWatch.Start();
            ParallelLoopResult plr = Parallel.ForEach(iList, SampleMean);
            stopWatch.Stop();
            Console.WriteLine("\nParallelLoopResult fertiggestellt: " + plr.IsCompleted +
                              "\nBenötigte Zeit:\t" + stopWatch.Elapsed +
                              "\nAnzahl eingesetzter Threads:\t" + tids.Count);
        } catch (Exception e) {
            Console.WriteLine(e);
        }
    }
}