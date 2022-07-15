using System;
public class Figur {
    protected int xpos = 100, ypos = 100;
	public Figur(int xpos_, int ypos_) {
		xpos = xpos_;
		ypos = ypos_;
		Console.WriteLine("Figur-Konstruktor");
	}
    public Figur() {}
    public void Wo() {
        Console.WriteLine("\nOben Links:\t(" + xpos + ", " + ypos + ") ");
    }
    static protected void ProSt() {
        Console.WriteLine("Protected und statisch!");
    }
}
