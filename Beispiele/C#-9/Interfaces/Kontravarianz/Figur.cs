using System;

public class Figur : IComparable<Figur> {
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

	public int CompareTo(Figur vergl) {
        if (xpos < vergl.xpos)
            return -1;
        else
            if (xpos > vergl.xpos)
            return 1;
        return 0;
    }
}