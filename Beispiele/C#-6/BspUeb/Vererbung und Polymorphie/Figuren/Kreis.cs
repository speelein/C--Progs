using System;
public class Kreis : Figur {
	double radius = 75.0;

	public Kreis(double x, double y, double rad) : base(x, y) {
		if (rad >= 0.0)
			radius = rad;
		Console.WriteLine("Kreis-Konstruktor");
	}
	public Kreis() { }

	public double Radius {
		get {return radius;}
        set {if (value >= 0.0) radius = value;}
	}
}
