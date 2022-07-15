// Datei Prog.cs
using System;
using StringExt;
using System.Linq;

class Prog {
	static void Main() {
		Console.WriteLine("".Empty());
		Console.WriteLine("m".Empty());

		int[] ints = { 10, 45, 15, 39, 21, 26 };
		var result = ints.OrderBy(g => g);
		foreach (var i in result) {
			Console.Write(i + " ");
		}
	}
}

