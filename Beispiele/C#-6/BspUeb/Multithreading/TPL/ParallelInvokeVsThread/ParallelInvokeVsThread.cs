using System;
using System.Threading;
using System.Threading.Tasks;

class ParallelInvokeVsThread {
	
	const int ANZ = 1000;
	static CountdownEvent ce;

	static void RandomSum() {
		Random zzg = new Random();
		double erg = 0.0;
		for (int j = 0; j < 10000; j++)
			erg += zzg.NextDouble();
		ce.Signal();
		//Console.WriteLine("RandomSum " + erg + " berechnet von Thread " + Thread.CurrentThread.ManagedThreadId);
	}

	static void Main() {
		Action[] av = new Action[ANZ];
		for (int i = 0; i < ANZ; i++)
			av[i] = new Action(RandomSum);

		ce = new CountdownEvent(ANZ);
		long start = DateTime.Now.Ticks;
		Parallel.Invoke(av);
		Console.WriteLine("Zeitaufwand per Invoke in Sek.: " + (DateTime.Now.Ticks - start) / 1.0e7);

		ce = new CountdownEvent(ANZ);
		start = DateTime.Now.Ticks;
		for (int i = 0; i < ANZ; i++)
			(new Thread(RandomSum)).Start();
		ce.Wait();
		Console.WriteLine("Zeitaufwand für einzelne Threads in Sek.: " + (DateTime.Now.Ticks - start) / 1.0e7);

		ce = new CountdownEvent(ANZ);
		start = DateTime.Now.Ticks;
		for (int i = 0; i < ANZ; i++)
			Task.Run(() => RandomSum());
		ce.Wait();
		Console.WriteLine("Zeitaufwand bei Threadpool-Items in Sek.: " + (DateTime.Now.Ticks - start) / 1.0e7);
	}
}