using System;
using System.Threading;

class MMDeadLock {
	bool warInM1, warInM2;
	static object lock1 = new object();
	static object lock2 = new object();

	void M1(object nr) {
		int nri = (int)nr;
		lock (lock1) {
			warInM1 = true;
			Console.WriteLine("Object " + nri + " (aktiv im Thread " +
				Thread.CurrentThread.Name + ") befindet sich in M1");
			Thread.Sleep(100);
			if (!warInM2) {
				Console.WriteLine("Object " + nri + " (aktiv im Thread " +
				Thread.CurrentThread.Name + ") möchte M2 aufrufen");
				M2(nr);
			}
		}
	}

	void M2(object nr) {
		int nri = (int)nr;
		lock (lock2) {
			warInM2 = true;
			Console.WriteLine("Object " + nri + " (aktiv im Thread " +
				Thread.CurrentThread.Name + ") befindet sich in M2");
			Thread.Sleep(100);
			if (!warInM1) {
				Console.WriteLine("Object " + nri + " (aktiv im Thread " +
					Thread.CurrentThread.Name + ") möchte M1 aufrufen");
				M1(nr);
			}
		}
	}

	static void Main() {
		MMDeadLock mm12 = new();
		MMDeadLock mm21 = new();
		Thread t1 = new(new ParameterizedThreadStart(mm12.M1));
		Thread t2 = new(new ParameterizedThreadStart(mm21.M2));
		t1.Name = "T1"; t1.Start(1);
		t2.Name = "T2"; t2.Start(2);
	}
}
