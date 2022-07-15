using System;

public static class StringExt {
	public static bool Empty(this String arg) {
		return arg != null && arg.Length == 0;
	}
}

class Prog {
	static void Main() {
		Console.WriteLine("".Empty());
		Console.WriteLine("m".Empty());
	}
}
