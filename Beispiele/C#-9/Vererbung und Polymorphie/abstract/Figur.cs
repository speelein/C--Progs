using System;
public abstract class Figur {
	protected double xpos = 100.0, ypos = 100.0;
	public Figur(double x, double y) {
		if (x >= 0.0 && y >= 0.0) {
			xpos = x;
			ypos = y;
		}
	}
	public Figur() { }

	public virtual void Wo() {
		Console.WriteLine("\nOben Links:\t(" + xpos + ", " + ypos + ") ");
	}

	public abstract void Skaliere(double faktor);

	public abstract double Inhalt {
		get;
	}

	public abstract double Breite {
		get;
	}
}