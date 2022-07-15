using System;
using System.Threading;
public class Produzent {
	Lager pl;
	bool offen;
	
	public Produzent(Lager ptr) {
		pl = ptr;
	}
	public void Run() {
		Random rand = new Random(1);
		do {
			offen = pl.Ergaenze(5 + rand.Next(100));
			Thread.Sleep(1000 + rand.Next(3000));
		} while (offen);
	}
}
