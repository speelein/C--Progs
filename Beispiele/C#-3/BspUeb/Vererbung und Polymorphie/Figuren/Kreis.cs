using System;
public class Kreis : Figur {
	double radius = 75.0;
	public Kreis(double x, double y, double rad) : base(x, y) {
		radius = rad;
		Console.WriteLine("Kreis-Konstruktor");
	}
	public Kreis() { }
	public double Radius {
		get { return radius; }
	}
}
