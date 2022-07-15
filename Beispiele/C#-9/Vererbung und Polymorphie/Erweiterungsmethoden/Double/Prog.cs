using System;

public static class Mathe {
	public static double H(this double arg, double expo) {
		return Math.Pow(arg, expo);
	}
}

class Prog {
	static void Main() {
		double pi = 3.14;
		Console.WriteLine(pi.H(2));
	}
}
