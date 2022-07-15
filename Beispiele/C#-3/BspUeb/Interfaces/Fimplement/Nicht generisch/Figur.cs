using System;
public class Figur : IComparable {
	string name = "unbenannt";
	double xpos, ypos;

	public Figur(string n, double x, double y) {
		name = n; xpos = x; ypos = y;
	}

	public Figur() {}

	public String Name {
		get { return name; }
	}

	public int CompareTo(object v) {
		Figur vergl = (Figur) v;
		if (xpos < vergl.xpos)
			return -1;
		else
			if (xpos > vergl.xpos)
				return 1;
		return 0;
	}
}
