using System;
using System.Threading;
public class Konsument {
	Lager pl;
	Random rand = new Random(2);

	public Konsument(Lager ptr) {
		pl = ptr;
	}

	public void Run() {
		while (pl.Liefere(5 + rand.Next(100)))
			Thread.Sleep(1000 + rand.Next(3000));
	}
}
