using System;
using System.Threading;

class DeadLock {
	static object lock1 = new object();
	static object lock2 = new object();

	static void m1() {
		lock (lock1) {
			Console.WriteLine(Thread.CurrentThread.Name+" in M1");
			Thread.Sleep(100);
			Console.WriteLine(Thread.CurrentThread.Name+" möchte M2 aufrufen");
            m2();
		}
	}

	static void m2() {
		lock (lock2) {
			Console.WriteLine(Thread.CurrentThread.Name+" in M2");
			Thread.Sleep(100);
			Console.WriteLine(Thread.CurrentThread.Name+" möchte M1 aufrufen");
			m1();
		}
	}

	static void Main() {
		Thread t1 = new Thread(new ThreadStart(m1));
		Thread t2 = new Thread(new ThreadStart(m2));
		t1.Name="T1"; t1.Start();
		t2.Name="T2"; t2.Start();
	}
}
