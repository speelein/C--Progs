using System;
using System.Linq;

class Qtype {
	public char Category { get; set; }
	public int Level { get; set; }
	public Qtype(char cat, int lev) {
		Category = cat; Level = lev;
	}
}

class ThenBy {
	static void Main() {
		var prods = new Qtype[5] { new('A', 3), new('B', 1), new('B', 2),
						           new('C', 2), new('C', 1) };
		var sortedProds = prods
						   .OrderBy(p => p.Category)
						   .ThenByDescending(p => p.Level);
		foreach (var p in sortedProds)
			Console.WriteLine(p.Category + " " + p.Level);
	}
}
