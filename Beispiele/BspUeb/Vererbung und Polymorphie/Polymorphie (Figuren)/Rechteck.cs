using System;
public class Rechteck : Figur {
	int breite = 50, hoehe = 50;

	public Rechteck(int xpos_, int ypos_, int breite_, int hoehe_) : base(xpos_, ypos_){
		breite = breite_;
		hoehe = hoehe_;
	}

    override public void Wo() {
		base.Wo();
		Console.WriteLine("Unten Rechtseck: (" + (xpos+breite) +
						", " + (ypos+hoehe) + ")");
	}
}
