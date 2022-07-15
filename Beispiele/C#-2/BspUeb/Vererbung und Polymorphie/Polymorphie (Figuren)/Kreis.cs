using System;
public class Kreis : Figur {
	int radius = 75;
	public Kreis(int xpos_, int ypos_, int rad_) : base(xpos_, ypos_) {
		radius = rad_;
	}
	override public void Wo() {
		base.Wo();
		Console.WriteLine("Unten Rechts:\t(" + (xpos+2*radius) +
						", " + (ypos+2*radius) + ")");
	}
}
