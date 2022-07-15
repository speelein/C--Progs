public class Figur {
	protected double xpos, ypos;

	public Figur(double x, double y) {
		if (x >= 0.0 && y >= 0.0) {
			xpos = x; ypos = y;
		}
	}
	public Figur() { }

	public double X { get { return xpos; } }
	public double Y { get { return ypos; } }
}