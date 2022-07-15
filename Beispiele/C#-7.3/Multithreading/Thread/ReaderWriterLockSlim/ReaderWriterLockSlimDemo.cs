using System;
using System.Threading;

class ReaderWriterLockSlimDemo {
	static Thread rt;
	static decimal dwert = 13.0M;
	static ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();

	static void WM() {
		//Console.WriteLine("*** Der Schreib-Thread startet.");
		for (int i = 1; i <= 3; i++) {
			rwls.EnterWriteLock();
				dwert++;
				Console.WriteLine("\n*** Schreibzugriff " + i + ". Neuer Wert: " + dwert + ", aktive Leser: " + rwls.CurrentReadCount + " (" + DateTime.Now.ToString() +")");
			rwls.ExitWriteLock();
			Thread.Sleep(3000);
		}
		//Console.WriteLine("*** Der Schreib-Thread endet.");
	}

	static void RM() {
		//Console.WriteLine(Thread.CurrentThread.Name + " startet.");
		for (int i = 1; i <= 3; i++) {
			rwls.EnterReadLock();
				Console.WriteLine(Thread.CurrentThread.Name + " ermittelt Wert " + dwert + ", aktive Leser: " + rwls.CurrentReadCount + " (" + DateTime.Now.ToString() + ")");
			rwls.ExitReadLock();
			Thread.Sleep(3000);
		}
		//Console.WriteLine(Thread.CurrentThread.Name + " endet.");
	}

	static void Main() {
		new Thread(WM).Start();
		for (int i = 0; i < 3; i++) {
			rt = new Thread(RM);
			rt.Name = "RT" + Convert.ToString(i);
			rt.Start();
		}
	}
}
