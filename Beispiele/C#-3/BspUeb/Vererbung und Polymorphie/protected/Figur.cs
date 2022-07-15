using System;
public class Figur {
	protected double xpos = 100.0, ypos = 100.0;
	public Figur(double x, double y) {
		xpos = x;
		ypos = y;
		Console.WriteLine("Figur-Konstruktor");
	}
	public Figur() { }
	public void Wo() {
		Console.WriteLine("\nOben Links:\t(" + xpos + ", " + ypos + ") ");
	}
	static protected void ProSt() {
		Console.WriteLine("Protected und statisch!");
	}
}
