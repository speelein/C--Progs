using System;
public class Rechteck : Figur {
	double breite = 50.0, hoehe = 50.0;

	public Rechteck(double x, double y, double b, double h)	: base(x, y) {
		if (breite >= 0.0 && hoehe >= 0.0) {
			breite = b;
			hoehe = h;
		}
	}

	public new void Wo() {
		base.Wo();
		Console.WriteLine("Unten Rechts: (" + (xpos + breite) +
						", " + (ypos + hoehe) + ")");
	}

	public override void Skaliere(double faktor) {
		if (faktor >= 0.0) {
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
