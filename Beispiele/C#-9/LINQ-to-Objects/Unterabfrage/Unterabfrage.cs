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

class Unterabfrage {
	static void Main() {
		var prods = new List<Product> { new('A', 1), new('A', 2), new('A', 1), new('A', 3),
			new('B', 4), new('B', 2), new('B', 3), new('B', 5), new('B', 4),
			new('C', 5), new('C', 6), new('C', 4), new('C', 8), new('C', 5) };

		var groups = from prod in prods
				group prod by prod.Supplier into supp
				select new { supp.Key, AvgQual = (from p in supp select p.Quality).Average() };

		foreach (var supp in groups) {
			Console.WriteLine("Lieferant: " + supp.Key + " Qualität: " + supp.AvgQual);
		}
	}
}
