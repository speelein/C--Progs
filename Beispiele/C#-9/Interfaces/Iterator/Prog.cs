using System;

class Prog {
	static void Main() {
        var si = new SimpleSortedList<int>(5) {
            11, 2, 1, 4, 7
        };

        Console.WriteLine("Standard-Iterator:");
		foreach (int i in si)
			Console.WriteLine(i);

		Console.WriteLine("\nAbwärts-Iterator:");
		foreach (int i in si.DownIt)
			Console.WriteLine(i);

		Console.WriteLine("\nBereichs-Iterator:");
		foreach (int i in si.RangeIt(1, 4))
			Console.WriteLine(i);

		Console.WriteLine("\nBereichs-Iterator Abwärts:");
		foreach (int i in si.RangeItUpDown(4, 1, 2))
			Console.WriteLine(i);

		Console.WriteLine("\nBereichüberschreitung:");
		foreach (int i in si.RangeIt(1, 14))
			Console.WriteLine(i);

        var sst = new SimpleSortedList<String>(5) {
            "one", "two", "three", "four", "five"
        };

        Console.WriteLine("\nStandard-Iterator (String):");
		foreach (string s in sst)
			Console.WriteLine(s);

	}
}
