using System;
public abstract class Figur {
	protected double xpos = 100.0, ypos = 100.0;
	public Figur(double x, double y) {
		xpos = x;
		ypos = y;
	}
	public Figur() { }
	public virtual void Wo() {
		Console.WriteLine("\nOben Links:\t(" + xpos + ", " + ypos + ") ");
	}
	public abstract void Wachse(double faktor);
	public abstract double Inhalt {
		get;
	}
	public abstract double Breite {
		get;
	}
}