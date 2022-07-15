using System;
class Prog {
	static void Main() {
		var ds = new SimpleStack<double>(10);
		ds.Push(3.141);
		ds.Push(2.718);
		for (int i = 1; ds.Count > 0; i++)
			Console.WriteLine("Oben lag: " + ds.Pop());
	}
}
