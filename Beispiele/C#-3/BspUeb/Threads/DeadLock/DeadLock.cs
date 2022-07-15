using System;
using System.Threading;

class DeadLock {
	static object lock1 = new object();
	static object lock2 = new object();

	static void M1() {
		lock (lock1) {
			Console.WriteLine(Thread.CurrentThread.Name+" in M1");
			Thread.Sleep(100);
			Console.WriteLine(Thread.CurrentThread.Name+" m�chte M2 aufrufen");
			M2();
		}
	}

	static void M2() {
		lock (lock2) {
			Console.WriteLine(Thread.CurrentThread.Name+" in M2");
			Thread.Sleep(100);
			Console.WriteLine(Thread.CurrentThread.Name+" m�chte M1 aufrufen");
			M1();
		}
	}

	static void Main() {
		Thread t1 = new Thread(new ThreadStart(M1));
		Thread t2 = new Thread(new ThreadStart(M2));
		t1.Name="T1"; t1.Start();
		t2.Name="T2"; t2.Start();
	}
}
