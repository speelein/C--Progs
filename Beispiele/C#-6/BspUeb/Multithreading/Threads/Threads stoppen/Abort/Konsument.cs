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
		try {
			do {
				offen = pl.Liefere((5 + rand.Next(100)));
				Thread.Sleep(1000 + rand.Next(3000));
			} while (offen);
		} catch (ThreadAbortException) {
			Console.WriteLine("Als Kunde muss ich mir so etwas " +
				"nicht gefallen lassen!");
		}
		// Ein finally-Block kann das Ende des Threads beliebig lange hinauszögern.
		//finally {
		//	double d;
		//	long i;
		//	for (i = 0; i < 9223372036854775807L; i++) {
		//		d = i * i;
		//		if (i%10000000 == 0)
		//			Console.WriteLine("Rumoren im finally-Block, i = " + i);
		//	}
		//}
	}
}
