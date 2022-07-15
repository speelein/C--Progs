using System;
public class Figur {
	double xpos = 100.0, ypos = 100.0;
	public Figur(double x, double y) {
		xpos = x;
		ypos = y;
		Console.WriteLine("Figur-Konstruktor");
	}
	public Figur() { }
	public void Wo() {
		Console.WriteLine("\nOben Links:\t(" + xpos + ", " + ypos + ") ");
	}
}
