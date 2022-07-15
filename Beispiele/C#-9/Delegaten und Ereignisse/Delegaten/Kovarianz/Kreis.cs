public class Kreis : Figur {
	protected double radius;

	public Kreis(double x, double y, double rad) : base(x, y) {
		if (rad >= 0.0) radius = rad;
	}
	public Kreis() { }

	public double Radius { get { return radius; } }
}