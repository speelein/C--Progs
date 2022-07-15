using System;
class Prog {
	static void Main() {
		Kreis krs = new Kreis(10.0, 10.0, 5.0);
        //krs.xpos = 77.7;    // In der Prog-Methode ist der Zugriff verboten.
		krs.Wo();
		krs.OLE2Zen();	// In der Kreis-Methode ist der Zugriff erlaubt.
		krs.Wo();
	}
}
