using System;
using System.Data;
using System.Data.SqlClient;

class ParamQuery {
	static void Main() {
		using SqlConnection dbConnection = new("Data Source=(LocalDb)\\MSSQLLocalDB; " +
						   "Initial Catalog=Northwind; Integrated Security=true");
		SqlCommand selAvgSupp = new("SELECT AVG(UnitPrice) FROM Products WHERE SupplierID = @Supp",
									dbConnection);
		selAvgSupp.Parameters.Add("@Supp", SqlDbType.Int);
		dbConnection.Open();
		while (true) {
			Console.Write("\nNummer das Anbieters (Beenden mit 0): ");
			int supp = Convert.ToInt32(Console.ReadLine());
			if (supp == 0)
				break;
			selAvgSupp.Parameters["@Supp"].Value = supp;
			Console.WriteLine("Mittlerer Preis aller Produkte von Anbieter " + supp +
			                  ": " + Convert.ToDouble(selAvgSupp.ExecuteScalar()));
		}
	}
}