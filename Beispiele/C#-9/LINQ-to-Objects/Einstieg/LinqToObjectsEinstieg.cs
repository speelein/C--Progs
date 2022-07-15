using System;
using System.Linq;

class Customer {
	public string CustomerId { get; set; }
	public string CompanyName { get; set; }
	public string Country { get; set; }
}

class LinqToObjectsEinstieg	{
	static void Main() {
		Customer[] customers = new Customer[7];
		customers[0] = new Customer { CustomerId = "ALFKI", CompanyName = "Alfreds Futterkiste", Country = "Germany" };
		customers[1] = new Customer { CustomerId = "ANATR", CompanyName = "Ana Trujillo Emparedados y helados", Country = "Mexico" };
		customers[2] = new Customer { CustomerId = "ANTON", CompanyName = "Antonio Moreno Taquería", Country = "Mexico" };
		customers[3] = new Customer { CustomerId = "AROUT", CompanyName = "Around the Horn", Country = "UK" };
		customers[4] = new Customer { CustomerId = "BERGS", CompanyName = "Berglunds snabbköp", Country = "Sweden" };
		customers[5] = new Customer { CustomerId = "BLAUS", CompanyName = "Blauer See Delikatessen", Country = "Germany" };
		customers[6] = new Customer { CustomerId = "BLONP", CompanyName = "Blondesddsl père et fils", Country = "France" };

		var custMex = customers
		               .Where(c => c.Country == "Mexico")
		               .Select(c => new { c.CustomerId, c.CompanyName });

		foreach (var c in custMex)
			Console.WriteLine(c.CustomerId + "  " + c.CompanyName);
	}
}
