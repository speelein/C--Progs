using System;
public class Kreis : Figur {
	double radius = 75.0;
	public Kreis(double x, double y, double rad) : base(x, y) {
		radius = rad;
	}
	public Kreis() { }
	public double Radius {
		get { return radius; }
	}
	public new void Wo() {
		base.Wo();
		Console.WriteLine("Unten Rechts:\t(" + (xpos + 2 * radius) +
		                ", " + (ypos + 2 * radius) + ")");
	}
}
