using System;

public struct R2VekS {
	// Datenkapselung ist hier nicht erforderlich, weil auf beide Koordinaten Lese- und
	// Schreibgriff erlaubt werden soll, und eine Änderung des Datentyps nicht in Frage kommt.
	public double X, Y;

	const double ZWEI_PI = Math.PI * 2;
	
	public R2VekS(double xpar, double ypar) {
		X = xpar;
		Y = ypar;
	}

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

	public void Addiere(R2VekS vpar) {
		X += vpar.X;
		Y += vpar.Y;
	}

    // Skalarprodukt
	public double SP(R2VekS vpar) {
		return X*vpar.X + Y*vpar.Y;
	}

	public double Winkel(R2VekS vpar) {
		double temp = SP(vpar)/(Laenge*vpar.Laenge);
		temp = Math.Acos(temp);
		temp = temp/ZWEI_PI * 360;
		return temp;
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
