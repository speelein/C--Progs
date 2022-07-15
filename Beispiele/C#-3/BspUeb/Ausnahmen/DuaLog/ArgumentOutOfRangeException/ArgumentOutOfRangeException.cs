using System;

class DuaLog {
	static double Log2 (double arg) {
		if (arg > 0)
			return Math.Log(arg) / Math.Log(2);
		else
			throw new ArgumentOutOfRangeException("arg", arg, "Log2-Argument muss > 0 sein.");
	}

	static void Main() {
		try {
			double a = Log2(-1);
			double b = Log2(8);
			Console.WriteLine(a * b);
		} catch (ArgumentOutOfRangeException e) {
			Console.WriteLine(e.Message);
		}
        Console.Read();
	}
}

