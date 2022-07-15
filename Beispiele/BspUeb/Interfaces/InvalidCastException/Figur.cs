using System;

public class Figur : IComparable {
    public string name = "unbenannt";
    public int xpos, ypos;

    public Figur(string name_, int xpos_, int ypos_) {
		name = name_; xpos = xpos_; ypos = ypos_;
	}

    public Figur() {}

    public int CompareTo(object obj) {
        return (xpos - ((Figur)obj).xpos);
	}
}
