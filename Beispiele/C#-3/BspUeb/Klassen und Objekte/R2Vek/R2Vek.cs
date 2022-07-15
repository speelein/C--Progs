using System;

public class R2Vek {
	// Datenkapselung ist hier nicht erforderlich, weil auf beide Koordinaten Lese- und
	// Schreibgriff erlaubt werden soll und eine Änderung des Datentyps nicht in Frage kommt.
	public double X = 1.0, Y;

	const double ZWEI_PI = Math.PI * 2;
	
	public R2Vek(double xpar, double ypar) {
		X = xpar;
		Y = ypar;
	}
	
	public R2Vek() {}
	
	public double Laenge {
		get {
			return Math.Sqrt(X*X + Y*Y);
		}
	}

	public void Normiere() {
		double b = Laenge;
		X /= b;
		Y /= b;				
	}

	public void Addiere(R2Vek vpar) {
		X += vpar.X;
		Y += vpar.Y;
	}

	// Skalarprodukt
	public double SP(R2Vek vpar) {
		return X*vpar.X + Y*vpar.Y;
	}

	public double Winkel(R2Vek vpar) {
		double temp = SP(vpar) / (Laenge*vpar.Laenge);
        return Math.Acos(temp) / ZWEI_PI * 360;
	}

	public void Drehe(double grad_) {
		double grad = grad_ % 360;
		double cosinus = Math.Cos(grad/360 * ZWEI_PI);
		double sinus = Math.Sin(grad/360 * ZWEI_PI);
		double oldX = X;
		X = cosinus*X - sinus*Y;
		Y = sinus*oldX + cosinus*Y;
	}
}
