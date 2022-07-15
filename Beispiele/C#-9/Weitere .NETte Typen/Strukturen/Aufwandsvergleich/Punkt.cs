using System;

public struct SPunkt {
    public double x, y;

	public SPunkt(double x_, double y_) {
		x = x_;
		y = y_;
	}

    public string Pos() {
			return "("+x+";"+y+")";
	}
}


public class CPunkt {
    public double x, y;

    public CPunkt(double x_, double y_) {
        x = x_;
        y = y_;
    }

    public CPunkt() { }

    public string Pos() {
        return "(" + x + ";" + y + ")";
    }

    //~CPunkt() {
    //    Console.WriteLine("Finalized...");
    //}
}