using System;
using System.Text;

class StrBldrDemo {
	static void Main() {
		const int n = 10_000;
		String s = "*";
		long vorher = DateTime.Now.Ticks; // Laden von DateTime
		vorher = DateTime.Now.Ticks;
		for (int i = 0; i < n; i++)
			s += "*";
		long diff = DateTime.Now.Ticks - vorher;
		Console.WriteLine("Zeit f�r String-Manipulation:\t\t" +
						  diff / 1.0e4 + "\tMillisekunden");

		var t = new StringBuilder("*");
		vorher = DateTime.Now.Ticks;
		for (int i = 0; i < n; i++)
			t.Append("*");
		diff = DateTime.Now.Ticks - vorher;
		Console.WriteLine("Zeit f�r StringBuilder-Manipulation:\t" +
						  diff / 1.0e4 + "\tMillisekunden");
	}
}
