using System;
public class Produzent {
	Lager lager;
    Random rand;
	
	public Produzent(Lager lager_) {
        lager = lager_;
        rand = new Random((int) DateTime.Now.Ticks + 1);
	}
	public void Run() {
		while (lager.Offen()) {
			lager.Ergaenze(5 + rand.Next(100));
			System.Threading.Thread.Sleep(1000 + rand.Next(3000));
		}
	}
}
