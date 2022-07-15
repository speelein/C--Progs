using System;

class Prog {
	static void Main() {
		var si = new SimpleSortedList<int>(5);
		si.Add(11); si.Add(2); si.Add(1); si.Add(4); si.Add(7);

		Console.WriteLine("Standard-Iterator:");
		foreach (int i in si)
			Console.WriteLine(i);

		Console.WriteLine("\nAbwärts-Iterator:");
		foreach (int i in si.DownIt)
			Console.WriteLine(i);

		Console.WriteLine("\nBereichs-Iterator:");
		foreach (int i in si.RangeIt(1, 4))
			Console.WriteLine(i);

		Console.WriteLine("\nBereichüberschreitung:");
		foreach (int i in si.RangeIt(1, 14))
			Console.WriteLine(i);

		var sst = new SimpleSortedList<String>(5);
		sst.Add("one"); sst.Add("two"); sst.Add("three"); sst.Add("four"); sst.Add("five");

		Console.WriteLine("\nStandard-Iterator (String):");
		foreach (string s in sst)
			Console.WriteLine(s);

	}
}
