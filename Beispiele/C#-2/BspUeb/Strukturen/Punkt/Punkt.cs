using System;

//public class Punkt {
public struct Punkt {	
    public double X, Y;

	public Punkt(double x_, double y_) {
		X = x_;
		Y = y_;
	}

//    public Punkt() { }

	public string Inhalt {
		get {
			return "("+X+";"+Y+")";
		}
	}
}
