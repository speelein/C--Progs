using System;
public class Kreis : Figur {
	double radius = 75.0;
	public Kreis(double x, double y, double rad) : base(x, y) {
		if (rad >= 0.0)
			radius = rad;
	}
	public Kreis() { }

	public double Radius {
		get { return radius; }
        set { if (value >= 0.0) radius = value; }
    }

	public override void Wo() {
		base.Wo();
		Console.WriteLine("Unten Rechts:\t(" + (xpos + 2.0 * radius) +
						", " + (ypos + 2.0 * radius) + ")");
	}

	public override void Skaliere(double faktor) {
		if (faktor >= 0.0)
			radius *= faktor;
	}

	public override double Inhalt {
		get {return Math.PI * radius * radius;}
	}

	public override double Breite {
		get {return radius * 2.0;}
	}
}
