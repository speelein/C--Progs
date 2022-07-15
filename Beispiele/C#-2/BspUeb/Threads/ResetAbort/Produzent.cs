using System;
using System.Threading;
public class Produzent {
	private Lager pl;
	
	public Produzent(Lager ptr) {
		pl = ptr;
	}
	public void Run() {
		Random rand = new Random();
		while (pl.Offen()) {
			pl.Ergaenze(5 + rand.Next(100));
			Thread.Sleep(1000 + rand.Next(3000));
		}
	}
}
