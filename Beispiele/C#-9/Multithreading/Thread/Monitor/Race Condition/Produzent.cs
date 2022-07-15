using System;
using System.Threading;
public class Produzent {
	Lager pl;
	Random rand = new Random(1);

	public Produzent(Lager ptr) {
		pl = ptr;
	}

	public void Run() {
		while (pl.Ergaenze(5 + rand.Next(100)))
			Thread.Sleep(1000 + rand.Next(3000));
	}
}
