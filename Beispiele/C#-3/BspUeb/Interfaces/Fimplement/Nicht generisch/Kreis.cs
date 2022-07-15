using System;
public class Kreis : Figur {
	double radius;
	public Kreis(string n, double x, double y, double r) : base(n, x, y) {
		radius = r;
	}
}