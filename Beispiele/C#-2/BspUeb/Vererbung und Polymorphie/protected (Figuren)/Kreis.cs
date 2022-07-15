using System;
public class Kreis : Figur {
	int radius = 75;
    public Kreis(int xpos_, int ypos_, int rad_) : base(xpos_, ypos_) {
	    radius = rad_;
	    Console.WriteLine("Kreis-Konstruktor");
    }
	public void SetzePos(int xpos_, int ypos_) {
		xpos = xpos_;
		ypos = ypos_;
	}
    public Kreis() {}
}
