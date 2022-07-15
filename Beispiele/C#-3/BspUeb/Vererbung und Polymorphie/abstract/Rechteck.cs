using System;
public class Rechteck : Figur {
	double breite = 50.0, hoehe = 50.0;

	public Rechteck(double x, double y, double b, double h)	: base(x, y) {
		breite = b;
		hoehe = h;
	}
	public Rechteck() { }

	public override void Wo() {
		base.Wo();
		Console.WriteLine("Unten Rechtseck: (" + (xpos+breite) +
						", " + (ypos+hoehe) + ")");
	}
	public override void Wachse(double faktor) {
		if (faktor > 0) {
			breite *= faktor;
			hoehe *= faktor;
		}
	}
	public override double Inhalt {
		get {return breite * hoehe;}
	}
	public override double Breite {
		get {return breite;}
	}
}
