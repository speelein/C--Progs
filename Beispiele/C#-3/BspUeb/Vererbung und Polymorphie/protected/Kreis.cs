using System;
public class Kreis : Figur {
	double radius = 75;
	public Kreis(double x, double y, double rad) : base(x, y) {
		radius = rad;
		Console.WriteLine("Kreis-Konstruktor");
	}
	public void SetzePos(double x, double y) {
		xpos = x;
		ypos = y;
	}
	public Kreis() {}
}
