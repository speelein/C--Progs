using System;
public class Konsument {
    Lager lager;
    Random rand;

    public Konsument(Lager lager_) {
        lager = lager_;
        rand = new Random((int) DateTime.Now.Ticks);
	}

    public void Run() {
		while (lager.Offen()) {
			lager.Liefere((5 + rand.Next(100)));
			System.Threading.Thread.Sleep(1000 + rand.Next(3000));
		}
	}
}
