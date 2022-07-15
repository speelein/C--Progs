using System;
using System.Collections.Generic;

class FindAll {
	static Predicate<String> ListLE(int k) {
		return (s => s.Length <= k ? true : false);
	}

	static void Main() {
        var list = new List<String>();
        list.Add("Doro"); list.Add("Liselotte"); list.Add("Friedrich");
        list.Add("Theo"); list.Add("Walter");

		Console.WriteLine("Liste der Kurznamen mit max. 4 Zeichen:");
		var k4 = list.FindAll(s => s.Length <= 4 ? true : false);
		foreach (string s in k4)
			Console.WriteLine(s);

		Console.WriteLine("\nVerwendung der Metamethode:");
		for (int i = 4; i <= 10; i += 2) {
			Console.WriteLine($"\nListe der Kurznamen mit max. {i} Zeichen:");
			var k = list.FindAll(ListLE(i));
			foreach (string s in k)
				Console.WriteLine(s);
		}
	}
}
