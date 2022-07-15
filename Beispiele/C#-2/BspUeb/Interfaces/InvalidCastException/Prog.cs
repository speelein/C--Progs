using System;
class Prog {
	static void Main() {
        IComparable[] ic = new IComparable[2];
        ic[0] = new Figur("F", 100, 100);
        ic[1] = 13;
        Array.Sort(ic);
	}
}
