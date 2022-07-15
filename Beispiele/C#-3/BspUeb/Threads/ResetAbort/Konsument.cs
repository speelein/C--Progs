using System;
using System.Threading;
public class Konsument {
	Lager pl;
	bool offen;
	
	public Konsument(Lager ptr) {
		pl = ptr;
	}

	public void Run() {
		Random rand = new Random(2);
		do {
			try {
				offen = pl.Liefere((5 + rand.Next(100)));
			} catch (ThreadAbortException) {
				Console.WriteLine("Als Kunde muss ich mir so etwas " +
					"nicht gefallen lassen!");
				Thread.ResetAbort();
			}
			Thread.Sleep(1000 + rand.Next(3000));
		} while (offen);
	}
}
