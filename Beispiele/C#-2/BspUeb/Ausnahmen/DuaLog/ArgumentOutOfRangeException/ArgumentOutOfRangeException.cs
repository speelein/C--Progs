using System;

class DuaLog {
	static double Log2 (double arg) {
		if (arg > 0)
			return Math.Log(arg) / Math.Log(2);
		else
			throw new ArgumentOutOfRangeException("arg", "Log2-Argument must be GT 0");
	}

	static void Main() {
		double a = Log2(8);
		double b = Log2(-1);
		Console.WriteLine(a*b);
        Console.ReadLine();
	}
}

