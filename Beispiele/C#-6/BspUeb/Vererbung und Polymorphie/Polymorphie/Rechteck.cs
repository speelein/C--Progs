using System;
public class Rechteck : Figur {
	double breite = 50.0, hoehe = 50.0;

	public Rechteck(double x, double y, double b, double h)	: base(x, y) {
		if (breite >= 0.0 && hoehe >= 0.0) {
			breite = b;
			hoehe = h;
		}
	}
	public Rechteck() { }

	public new void Wo() {
		base.Wo();
		Console.WriteLine("Unten Rechts: (" + (xpos + breite) +
						", " + (ypos + hoehe) + ")");
	}
}