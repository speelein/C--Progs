using System;
class Prog {
	static void Main() {
		Figur f = new Figur(10.0, 20.0);
		f.Wo();
		Kreis k = new Kreis(50.0, 50.0, 10.0);
		k.Wo();

        Figur[] fa = new Figur[5];
        fa[0] = new Figur(10.0, 10.0);
        fa[1] = new Rechteck(20.0, 20.0, 20.0, 20.0);
        fa[2] = new Kreis(30.0, 30.0, 30.0);
        fa[3] = new Kreis(40.0, 40.0, 30.0);
        fa[4] = new Figur(50.0, 50.0);
        foreach (Figur e in fa)
            e.Wo();
    }
}
