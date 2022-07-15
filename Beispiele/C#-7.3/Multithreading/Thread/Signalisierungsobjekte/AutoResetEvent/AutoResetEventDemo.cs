using System;
using System.Threading;

class AutoResetEventDemo {
	static Thread t1, t2;
	static AutoResetEvent are = new AutoResetEvent(false); // Signal ist initial aus.

	static void M() {
		int t = 1;
		if (Thread.CurrentThread == t2) {
			t = 2;
			are.WaitOne(); // t2 geht als erster in den Wartzuestand.
		}
		for (int j = 1; j <= 2; j++) {
			Console.Write("\n" + Thread.CurrentThread.Name + " ist am Zug: ");
			for (int i = 1; i <= 5; i++) {
				Console.Write(t + " ");
				Thread.Sleep(200);
			}
			Console.WriteLine("\n" + Thread.CurrentThread.Name + " Setzt das Signal und dann sich selbst zur Ruhe.");
			are.Set();
			Thread.Sleep(10); // Nötig, damit der andere Thread das Signal verbraucht.
			are.WaitOne();
		}
		Console.WriteLine("\n"+Thread.CurrentThread.Name+" endet.");
		are.Set(); // Nötig, damit der wartende Kollege zum letzten Auftritt geweckt wird.
	}

	static void Main() {
		t1 = new Thread(M);
		t2 = new Thread(M);
		t1.Name = "t1";
		t2.Name = "t2"; 
		t1.Start();
		t2.Start();
	}
}
