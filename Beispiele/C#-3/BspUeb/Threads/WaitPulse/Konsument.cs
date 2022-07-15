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
			offen = pl.Liefere((5 + rand.Next(100)));
			Thread.Sleep(1000 + rand.Next(3000));
		} while (offen);
	}
}