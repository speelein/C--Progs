using System;

public class Figur {
	protected String name = "unbenannt";
	protected double xpos, ypos;

	public Figur(string n, double x, double y) {
		name = n;
		if (x >= 0.0 && y >= 0.0) {
			xpos = x;
			ypos = y;
		}
	}
	public Figur() { }

	public String Name { get { return name; } }
	public double X { get { return xpos; } }
	public double Y { get { return ypos; } }
}
