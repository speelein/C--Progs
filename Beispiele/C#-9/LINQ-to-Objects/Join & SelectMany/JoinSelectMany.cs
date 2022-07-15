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

	class Supplier {
		public char Id { get; set; }
		public string Name { get; set; }
		public Supplier(char id, string name) {
			Id = id; Name = name;
		}
	}

class JoinSelectMany {
	static void Main() {
		var prods = new List<Product> { new('A', 1), new('A', 2), new('A', 1), new('A', 3),
			new('B', 4), new('B', 2), new('B', 3), new('B', 5), new('B', 4),
			new('C', 5), new('C', 6), new('C', 4), new('C', 8), new('C', 5) };

		var supps = new List<Supplier> { new('A', "Your Source"),
			new('B', "Professional Parts"), new('C', "Buy, buy") };

        var prodsAugm = prods.Join(supps, p => p.Supplier, s => s.Id,
                                    (p, s) => new { p.Supplier, s.Name, p.Quality });

      //  var prodsAugm = from p in prods
						//join s in supps
						//on p.Supplier equals s.Id
						//select new { p.Supplier, s.Name, p.Quality };
		Console.WriteLine("Inner Join:");
		foreach (var p in prodsAugm)
			Console.WriteLine($"Lieferant: {p.Supplier} {p.Name,-20} Qualität: {p.Quality}");

		var prodsAugmSM = supps.SelectMany(s => prods
		                                         .Where(p => p.Supplier == s.Id)
									             .Select(p => new { p.Supplier, s.Name, p.Quality }));
		Console.WriteLine("\nInner Join per SelectMany():");
		foreach (var p in prodsAugmSM)
			Console.WriteLine($"Lieferant: {p.Supplier} {p.Name,-20} Qualität: {p.Quality}");

		var places = new List<string> { "York Town", "Tock Village", "Bingten" };
		var placesWithSupps = supps.SelectMany(s => places.Select(p => new {Place = p , Supplier = s.Name }));
		Console.WriteLine("\nCross Join:");
		foreach (var p in placesWithSupps)
			Console.WriteLine($"Lieferant: {p.Supplier,-20} in: {p.Place}");

		var prodsAugmSMA = from   s in supps
							from   p in prods
							where  s.Id == p.Supplier
							select new { p.Supplier, s.Name, p.Quality };
		Console.WriteLine("\nInner Join per SelectMany() mit Abfrageausdruck:");
		foreach (var p in prodsAugmSMA)
			Console.WriteLine($"Lieferant: {p.Supplier} {p.Name,-20} Qualität: {p.Quality}");

		var placesWithSuppsA = from s in supps
							   from p in places
							   select new { Place = p, Supplier = s.Name };
		Console.WriteLine("\nCross Join mit Abfrageausdruck:");
		foreach (var p in placesWithSupps)
			Console.WriteLine($"Lieferant: {p.Supplier,-20} in: {p.Place}");
	}
}
