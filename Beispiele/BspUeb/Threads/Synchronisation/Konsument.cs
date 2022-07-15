using System;
using System.Threading;
public class Konsument {
	private Lager pl;
	
	public Konsument(Lager ptr) {
		pl = ptr;
	}

	public void Run() {
		Random rand = new Random(4711);
		while (pl.Offen()) {
			pl.Liefere((5 + rand.Next(100)));
			Thread.Sleep(1000 + rand.Next(3000));
		}
	}
}
