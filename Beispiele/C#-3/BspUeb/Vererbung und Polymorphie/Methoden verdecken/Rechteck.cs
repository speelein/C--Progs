using System;
public class Rechteck : Figur {
	double breite = 50.0, hoehe = 50.0;

	public Rechteck(double x, double y, double b, double h)
		: base(x, y) {
		breite = b;
		hoehe = h;
	}

	public new void Wo() {
		base.Wo();
		Console.WriteLine("Unten Rechtseck: (" + (xpos+breite) +
						", " + (ypos+hoehe) + ")");
	}
}
