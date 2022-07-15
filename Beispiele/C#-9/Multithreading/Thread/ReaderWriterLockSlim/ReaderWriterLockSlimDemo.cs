using System;
using System.Threading;

class ReaderWriterLockSlimDemo {
	static decimal dwert = 13.0M;
	static readonly ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();

	static void WM() {
		for (int i = 1; i <= 3; i++) {
			rwls.EnterWriteLock();
			dwert++;
			Console.WriteLine("\n*** Schreibzugriff " + i + ". Neuer Wert: " + dwert +
			  ", aktive Leser: " + rwls.CurrentReadCount + " (" + DateTime.Now.ToString() + ")");
			Thread.Sleep(2000);
			rwls.ExitWriteLock();
			Thread.Sleep(1000);
		}
	}

	static void RM() {
		for (int i = 1; i <= 3; i++) {
			rwls.EnterReadLock();
			Console.WriteLine(Thread.CurrentThread.Name + " ermittelt Wert " + dwert +
			  ", aktive Leser: " + rwls.CurrentReadCount + " (" + DateTime.Now.ToString() + ")");
			Thread.Sleep(500);
			rwls.ExitReadLock();
			Thread.Sleep(1000);
		}
	}

	static void Main() {
		new Thread(WM).Start();
		Thread rt;
		for (int i = 0; i < 3; i++) {
			Thread.Sleep(50);
			rt = new Thread(RM);
			rt.Name = "RT" + Convert.ToString(i);
			rt.Start();
		}
	}
}
