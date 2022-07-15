using System;
public class Kreis : Figur {
	int radius = 75;
	public Kreis(int xpos_, int ypos_, int rad_) : base(xpos_, ypos_) {
		radius = rad_;
		Console.WriteLine("Kreis-Konstruktor");
	}
    public Kreis() { }
}
