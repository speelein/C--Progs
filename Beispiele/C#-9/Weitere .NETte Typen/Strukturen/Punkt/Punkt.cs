//public class Punkt {
public struct Punkt {
    double x, y;

	public Punkt(double x_, double y_) {
		x = x_;
		y = y_;
	}

	//public Punkt() { }

	// Nutzlose bzw. gefährlich irreführende Methode:
	public static void Bewegen(Punkt p, double hor, double vert) {
		p.x += hor;
		p.y += vert;
	}

	public void Bewegen(double hor, double vert) {
		x += hor;
		y += vert;
	}

	public string Pos() {
		return "("+x+";"+y+")";
	}
}
