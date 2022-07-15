using System;
using System.Linq;
using LinqToSqlKonsole;

class LinqToSqlDbMod {
	static NorthwindDataContext dc = new NorthwindDataContext();

	static void PrintData() {
		var germCust = from c in dc.Customers
					   where c.Country == "Germany"
					   select new { c.CustomerID, c.CompanyName, c.Country };
		foreach (var c in germCust)	{
			Console.WriteLine(c.CustomerID + "\t" + c.Country + "\t" + c.CompanyName);
		}
		Console.WriteLine();
	}

	static void ChangeData() {
		var cust = dc.Customers.Where(c => c.CustomerID == "ALFKI");
		if (cust.Count() > 0) {
			var alfki = cust.First();
			if (alfki.CompanyName == "Alfreds Kutterkiste")
				alfki.CompanyName = "Alfreds Futterkiste";
			else
				alfki.CompanyName = "Alfreds Kutterkiste";
			dc.SubmitChanges();
		}
	}

	static void CreateEntity() {
		var cust = dc.Customers.Where(c => c.CustomerID == "NEWEN");
		if (cust.Count() == 0) {
			Console.WriteLine("Creating new Entity NEWEN\n");
			Customers newCust = new Customers {
				CustomerID = "NEWEN",
				CompanyName = "LINQ to SQL",
				ContactName = "Default-Contact",
				ContactTitle = "Default-Title",
				Address = "Default-Address",
				City = "Default-City",
				Region = "Default-Region",
				PostalCode = "00000",
				Country = "Germany",
				Phone = "00000",
				Fax = "00000"};
			dc.Customers.InsertOnSubmit(newCust);
			dc.SubmitChanges();
		}
	}

	static void DeleteEntity() {
		var cust = dc.Customers.Where(c => c.CustomerID == "NEWEN");
		if (cust.Count() > 0) {
			Console.WriteLine("Deleting Entity NEWEN\n");
			dc.Customers.DeleteOnSubmit(cust.First());
			dc.SubmitChanges();
		}
	}

	static void Main(){
		Console.WriteLine("Customers from Germany - Start");
		PrintData();
		Console.ReadLine();

		ChangeData();
		Console.WriteLine("Customers from Germany - After Change");
		PrintData();
		Console.ReadLine();

		CreateEntity();
		Console.WriteLine("Customers from Germany - After Create");
		PrintData();
		Console.ReadLine();
		
		DeleteEntity();
		Console.WriteLine("Customers from Germany - After Delete");
		PrintData();
		Console.ReadLine();
	}
}