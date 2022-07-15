public class Punkt {
//public struct Punkt {	
	double x, y;

	public Punkt(double x_, double y_) {
		x = x_;
		y = y_;
	}

	public Punkt() { }

	public static void Bewegen(Punkt p, double hor, double vert) {
		p.x = p.x + hor;
		p.y = p.y + vert;
	}

	public void Bewegen(double hor, double vert) {
		x = x + hor;
		y = y + vert;
	}

	public string Pos() {
		return "("+x+";"+y+")";
	}
}
