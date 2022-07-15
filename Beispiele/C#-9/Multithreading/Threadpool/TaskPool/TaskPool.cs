using System;
using System.Threading;
using System.Threading.Tasks;

class TaskPool {
	static long start;

	static void G1Task(Object nr) {
		Random zzg = new Random();
		const int SIZE = 10;
		for (int i = 0; i < 4; i++) {
			double[] d = new double[SIZE];
			d[0] = (int)nr;
			d[1] = i;
			for (int j = 2; j < SIZE; j++)
				d[j] = zzg.Next(SIZE);
			//ThreadPool.QueueUserWorkItem(Childtask, d);
			//Task.Factory.StartNew(ChildTask, d);
			//Task.Factory.StartNew(() => Childtask(d));
			Task.Run(() => G2Task((object)d));
		}
		long dauer = DateTime.Now.Ticks - start;
		Console.WriteLine($"G1Task {nr}, Zeit seit Start: {(dauer/1.0e7),6:f4} Sek., " +
							$"ThreadId: {Thread.CurrentThread.ManagedThreadId}");
	}

	static void G2Task(Object da) {
		double[] d = (double[])da;
		double summe = 0.0;
		for (int i = 0; i < 10_000_000; i++) {
			summe = 0.0;
			for (int j = 0; j < d.Length; j++)
				summe += d[j] * d[j];
		}
		long dauer = DateTime.Now.Ticks - start;
		Console.WriteLine($"G2Task ({d[0]},{d[1]})" +
				 $", Zeit seit Start: {(dauer / 1.0e7),6:f4} Sek., " +
				 $"ThreadId: {Thread.CurrentThread.ManagedThreadId}");
	}

	static void G2Task(double[] d) {
		double summe = 0.0;
		for (int i = 0; i < 10000000; i++) {
			summe = 0.0;
			for (int j = 0; j < d.Length; j++)
				summe += d[j] * d[j];
		}
		long dauer = DateTime.Now.Ticks - start;
		Console.WriteLine($"ChildTask ({d[0]},{d[1]})" +
					$", Zeit seit Start: {(dauer / 1.0e7),6:f4} Sek., " +
					$"ThreadId: {Thread.CurrentThread.ManagedThreadId}");
	}

	static int ActiveWorkerThreads() {
		int availableWorker, availableIO, maxWorker, maxIO;
		ThreadPool.GetAvailableThreads(out availableWorker, out availableIO);
		ThreadPool.GetMaxThreads(out maxWorker, out maxIO);
		return maxWorker - availableWorker;
	}

	static void Main() {
		start = DateTime.Now.Ticks;
        const int ANZ = 4;
		for (int i = 0; i < ANZ; i++) {
			//ThreadPool.QueueUserWorkItem(G1Task, i);
			Task.Factory.StartNew(G1Task, i);
			//Console.WriteLine("Aktive Worker-Threads: " + ActiveWorkerThreads());
		}
		Console.ReadLine(); // Hält den Vordergrund-Thread aktiv, damit die Anwendung nicht abgebrochen wird.
	}
}