using System;
public class Kreis : Figur {
	double radius = 75.0;
	public Kreis(double x, double y, double rad) : base(x, y) {
		radius = rad;
	}
	public Kreis() { }
	public override void Wo() {
		base.Wo();
		Console.WriteLine("Unten Rechts:\t(" + (xpos+2*radius) +
						", " + (ypos+2*radius) + ")");
	}
	public override void Wachse(double faktor) {
		if (faktor > 0)
			radius *= faktor;
	}
	public double Radius {
		get {return radius;}
	}
	public override double Inhalt {
		get {return Math.PI * radius * radius;}
	}
	public override double Breite {
		get {return radius*2;}
	}
}
