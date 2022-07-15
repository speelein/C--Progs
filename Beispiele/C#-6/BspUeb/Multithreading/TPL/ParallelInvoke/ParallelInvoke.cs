using System;
using System.Threading;
using System.Threading.Tasks;

class ParallelInvoke {
	const int ANZ = 16;
	const int SG = 10000000;

	static void SampleMean() {
		Random zzg = new Random();
		double erg = 0.0;
		for (int j = 0; j < SG; j++)
			erg += zzg.NextDouble();
		Console.WriteLine("Stichprobenmittel " + (erg / SG) + " berechnet von Thread " +
						  Thread.CurrentThread.ManagedThreadId);
	}

	static void Main() {
		Action[] av = new Action[ANZ];
		for (int i = 0; i < ANZ; i++)
			av[i] = new Action(SampleMean);
		long start = DateTime.Now.Ticks;
		Parallel.Invoke(av);
		Console.WriteLine("Benötigte Zeit in Sek.: " +
						  (DateTime.Now.Ticks - start) / 1.0e7);
	}
}
