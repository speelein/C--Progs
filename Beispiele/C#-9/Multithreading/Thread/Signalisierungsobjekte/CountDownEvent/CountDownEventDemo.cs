using System;
using System.Threading;

class CountDownEventDemo {
	static CountdownEvent cde;

	static void M() {
		Console.WriteLine("Thread-Rakete bereit, wartet auf CountdownEvent.");
		cde.Wait();
		Console.WriteLine("\n\nThread-Rakete startet:");
		for (int i = 1; i <= 16; i++) {
			Console.Write(".");
			for (int j = 0; j < i/2; j++) Console.Write(' ');
			Thread.Sleep(300);
		}
		Console.ReadLine();
	}

	static void Main() {
		int cdStart = 10;
		cde = new CountdownEvent(cdStart);
		new Thread(M).Start();
		Thread.Sleep(100);
		Console.WriteLine("\nCountdown läuft:");
		for (int i = cdStart; i > 0; i--) {
			Console.Write(i + " ");
			cde.Signal();
			Thread.Sleep(500);
		}
	}
}
