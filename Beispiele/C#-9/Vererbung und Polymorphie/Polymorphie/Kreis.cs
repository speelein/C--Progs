using System;
public class Kreis : Figur {
	double radius = 75.0;

	public Kreis(double x, double y, double rad) : base(x, y) {
		if (rad >= 0.0)
			radius = rad;
	}
	public Kreis() { }

    public double Radius {
	    get {return radius;}
        set {if (value >= 0.0) radius = value;}
    }

	protected override void Wo() {
		base.Wo();
		Console.WriteLine("Unten Rechts:\t(" + (xpos + 2.0 * radius) +
						", " + (ypos + 2.0 * radius) + ")");
	}
}