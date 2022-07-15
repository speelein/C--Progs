using System;
using System.Linq;

class SonstErwMethoden {
	static void Main() {
        int[] ints = { 1, 3, 5, 7, 9, 12 };

		Console.WriteLine("Take()");
		var take3 = ints.Take(3);
		foreach (var e in take3) Console.Write(e + " ");

		Console.WriteLine("\n\nTakeLast()");
		var takeLast3 = ints.TakeLast(3);
		foreach (var e in takeLast3) Console.Write(e + " ");

		Console.WriteLine("\n\nFirst(), Last(), ElementAt()");
		var firstElem = ints.First(); var lastElem = ints.Last();
		var secondElem = ints.ElementAt(1);
		Console.Write(firstElem + ", " + secondElem + ", " + lastElem);

		Console.WriteLine("\n\nSkip()");
		var rest = ints.Skip(2);
		foreach (var e in rest) Console.Write(e + " ");

		Console.WriteLine("\n\nReverse()");
		var umgekehrt = ints.Reverse();
		foreach (var e in umgekehrt) Console.Write(e + " ");

		Console.WriteLine("\n\nSum(), Average()");
		Console.Write(ints.Sum() + ", " + ints.Average());

		Console.WriteLine("\n\nCount()");
		Console.Write(ints.Count());

		Console.WriteLine("\n\nMin(), Max()");
		Console.Write(ints.Min() + ", " + ints.Max());

		Console.WriteLine("\n\nContains()");
		Console.Write(ints.Contains(5));

		Console.WriteLine("\n\nAll(), Any()");
		Console.Write(ints.All(n => n % 2 == 0) + ", " +
		              ints.Any(n => n % 2 == 0));
		var empty = ints.Where(i => i <-1);
		Console.WriteLine("\nAll() in an empty sequence:\n" +
							empty.All(i => i > 77));
		Console.WriteLine("First of empty sequence: " + empty.FirstOrDefault());

		Console.WriteLine("\nSingle()");
		Console.WriteLine(ints.Where(i => i > 10).Single());
		Console.WriteLine(ints.Single(i => i < 3));

		int[] first = { 1, 2, 3 };
		int[] second = { 2, 3, 4 };
		Console.WriteLine("\nConcat()");
		var result = first.Concat(second);
		foreach (var e in result) Console.Write(e + " ");

		Console.WriteLine("\n\nUnion()");
		result = first.Union(second);
		foreach (var e in result) Console.Write(e + " ");

		Console.WriteLine("\n\nIntersect()");
		result = first.Intersect(second);
		foreach (var e in result) Console.Write(e + " ");

		Console.WriteLine("\n\nExcept()");
		result = first.Except(second);
		foreach (var e in result) Console.Write(e + " ");

		Console.WriteLine("\n\nDistinct()");
		int[] intsd = { 1, 3, 3, 7, 7, 12 };
		result = intsd.Distinct();
		foreach (var e in result) Console.Write(e + " ");
	}
}
