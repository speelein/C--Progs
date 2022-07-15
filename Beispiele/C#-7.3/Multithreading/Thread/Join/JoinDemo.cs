using System;
using System.Threading;

class JoinDemo {
	static Thread t1, t2;

	static void M1() {
		Console.WriteLine("t1 in M1");
		Thread.Sleep(100);
		Console.WriteLine("\nt1 beginnt seine Arbeit:");
		for (int i = 1; i <= 3; i++) {
			Console.Write(1 + " ");
			Thread.Sleep(500);
		}
		Console.WriteLine("\nt1 beendet");
	}

	static void M2() {
		Console.WriteLine("t2 in M2, wartet auf t1");
		t1.Join();
		Console.WriteLine("\nt2 beginnt seine Arbeit:");
		for (int i = 1; i <= 3; i++) {
			Console.Write(2 + " ");
			Thread.Sleep(500);
		}
		Console.WriteLine("\nt2 beenden mit Enter");
		Console.Read();
	}

	static void Main() {
		t1 = new Thread(new ThreadStart(M1));
		t2 = new Thread(new ThreadStart(M2));
		t1.Start();
		t2.Start();
	}
}
