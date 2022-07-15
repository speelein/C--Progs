using System;
using System.Collections.Generic;
using System.Linq;

class Product {
	public char Supplier {get; set;}
	public int Quality {get; set;}
	public Product(char supp, int qual) {
		Supplier = supp; Quality = qual;
	}
}

class Gruppieren {
	static void Main() {
		var prods = new List<Product> { new('A', 1), new('A', 2), new('A', 1), new('A', 3),
			new('B', 4), new('B', 2), new('B', 3), new('B', 5), new('B', 4),
			new('C', 5), new('C', 6), new('C', 4), new('C', 8), new('C', 5) };

        var groups = prods.GroupBy(p => p.Supplier);

		//var groups = from prod in prods
		//             group prod by prod.Supplier;

		//var groups = from prod in prods
		//               group prod by prod.Supplier <= 'B';

		//var groups = prods.GroupBy(p => p.Supplier <= 'B');

		//var groups = from prod in prods
		//             group prod by new { prod.Supplier, HighQual = prod.Quality > 5 };

		//var groups = prods.GroupBy(p => new { p.Supplier, HighQual = p.Quality > 5 });

		foreach (var supp in groups) {
			Console.WriteLine("\nLieferant: " + supp.Key);
			//var qualRatings = from p in supp select p.Quality;
			Console.WriteLine($" Mittlere Qualität: {supp.Select(p => p.Quality).Average()}");
			foreach (var prod in supp)
				Console.Write(" " + prod.Quality);
			Console.WriteLine();
		}
	}
}
