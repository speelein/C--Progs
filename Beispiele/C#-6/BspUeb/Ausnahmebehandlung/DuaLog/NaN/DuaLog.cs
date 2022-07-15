using System;

class DuaLog {
	static double Log2(double arg) {
		return Math.Log(arg) / Math.Log(2);
	}

	static void Main() {
		double a = Log2(-1);
		double b = Log2(8);
		Console.WriteLine(a*b);
	}
}

