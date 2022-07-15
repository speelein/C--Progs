using System;
using System.Threading;

class CountDownEventDemo {
	static CountdownEvent cds;

	static void M() {
		Console.WriteLine("Thread-Rakete bereit, wartet auf CountdownEvent.");
		cds.Wait();
		Console.WriteLine("\n\nThread-Rakete startet:");
		for (int i = 1; i <= 16; i++) {
			Console.Write(".");
			for (int j = 0; j < i/2; j++) Console.Write(' ');
			Thread.Sleep(300);
		}
		Console.ReadLine();
	}

	static void Main() {
		int cdn = 10;
		cds = new CountdownEvent(cdn);
		new Thread(M).Start();
		Thread.Sleep(100);
		Console.WriteLine("\nCountdown läuft:");
		for (int i = cdn; i > 0; i--) {
			Console.Write(i+" ");
			cds.Signal();
			Thread.Sleep(500);
		}
	}
}
