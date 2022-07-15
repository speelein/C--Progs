using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Customer {
	public String CustomerID;
	public String CompanyName;
	public String Country;
}

class LinqToObjects {
	static void Main() {
		Customer[] customers = new Customer[7];
		customers[0] = new Customer { CustomerID = "ALFKI", CompanyName = "Alfreds Futterkiste", Country = "Germany" };
		customers[1] = new Customer { CustomerID = "ANATR", CompanyName = "Ana Trujillo Emparedados y helados", Country = "Mexico" };
		customers[2] = new Customer { CustomerID = "ANTON", CompanyName = "Antonio Moreno Taquería", Country = "Mexico" };
		customers[3] = new Customer { CustomerID = "AROUT", CompanyName = "Around the Horn", Country = "UK" };
		customers[4] = new Customer { CustomerID = "BERGS", CompanyName = "Berglunds snabbköp", Country = "Sweden" };
		customers[5] = new Customer { CustomerID = "BLAUS", CompanyName = "Blauer See Delikatessen", Country = "Germany" };
		customers[6] = new Customer { CustomerID = "BLONP", CompanyName = "Blondesddsl père et fils", Country = "France" };

		// Erweiterungsmethoden-Syntax
		//var cust = customers.
		//            Where(c => c.Country == "Mexico").
		//            Select(c => new { c.CustomerID, c.Country });

		// from, select
		//var custIds = from c in customers select c.CustomerID;
		//var custIds = customers.Select(c => c.CustomerID);

		// Verzögerte Select-Ausführung
		//Console.WriteLine(customers[6].CustomerID);
		//var custIds = customers.Select(c => c.CustomerID);
		//customers[6].CustomerID = "SEVEN";
		//Console.WriteLine(custIds.ElementAt(6));
		//customers[6].CustomerID = "SIEBEN";
		//Console.WriteLine(custIds.ElementAt(6));
	
		// Select mit einem zusammengesetzten anonymen Abfragetyp
		//var cust = from c in customers
		//           select new { c.CustomerID, c.Country };
		//var cust = customers.Select(c => new {c.CustomerID, c.Country});
		//foreach (var c in cust)
		//    Console.WriteLine(c.CustomerID + " " + c.Country);

		// Where
		//var cust = customers
		//                    .Where(c => c.Country == "Mexico")
		//                    .Select(c => new { c.CustomerID, c.Country });
		var cust = from c in customers
							where c.Country == "Mexico"
							select new { c.CustomerID, c.Country };
		foreach (var c in cust)
			Console.WriteLine(c.CustomerID);

		// Range
		//IEnumerable<char> schars = Enumerable.Range(65, 26).Select(i => (char) i);
		//foreach (char c in schars) {
		//    Console.WriteLine((int) c + "\t" + c);
		//}
		//Console.WriteLine(schars.ElementAt(3));

		// orderby
		//cust = from c in customers
		//        orderby c.Country
		//        select new {c.CustomerID, c.Country};
		//foreach (var c in cust)
		//    Console.WriteLine(c.CustomerID + " " + c.Country);

		// Quelle erfüllt nur die nicht-generische Schnittstelle IEnumerable
		//ArrayList al = new ArrayList();
		//al.Add("Eins");
		//al.Add(13);
		//var alab = from object c in al select c;

		Console.ReadLine();
	}
}
