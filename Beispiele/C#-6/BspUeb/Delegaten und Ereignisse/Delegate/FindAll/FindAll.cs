using System;
using System.Collections.Generic;

class FindAll {
	static Predicate<String> ListLE(int k) {
		return (s => s.Length <= k ? true : false);
	}

	static void Main() {
		var list = new List<String> { "Doro", "Liselotte", "Friedrich", "Theo", "Walter" };

		Console.WriteLine("Liste der Kurznamen mit max. 4 Zeichen:");
		var k4 = list.FindAll(s => s.Length <= 4 ? true : false);
		foreach (string s in k4)
			Console.WriteLine(s);

		Console.WriteLine("\nVerwendung der Metamethode:");
		for (int i = 4; i < 10; i++) {
			Console.WriteLine($"\nListe der Kurznamen mit max. {i} Zeichen:");
			var k = list.FindAll(ListLE(i));
			foreach (string s in k)
				Console.WriteLine(s);
		}
	}
}
