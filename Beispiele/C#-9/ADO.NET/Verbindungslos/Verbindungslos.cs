using System;
using System.Data;
using System.Data.SqlClient;

class Verbindungslos {
	static DataTable dtCustomers, dtOrders;
	static string selCus = "SELECT CustomerID, CompanyName, Country FROM Customers",
				  selOrd = "SELECT OrderID, CustomerID, ShipCountry FROM Orders",
				  cs = "Data Source=(LocalDb)\\MSSQLLocalDB; " +
						   "Initial Catalog=Northwind; Integrated Security=true";

	static void ReadData(string cs, string selCus, string selOrd) {
		using SqlConnection dbConnection = new(cs);
		using SqlCommand selCommandCus = new(selCus, dbConnection);
		using SqlCommand selCommandOrd = new(selOrd, dbConnection);
		using SqlDataAdapter dbAdapterCus = new(selCommandCus);
		using SqlDataAdapter dbAdapterOrd = new(selCommandOrd);

		DataSet ds = new();

		// Das explizite Öffnen und Schließen der Datenbankverbindung vermeidet
		// die wiederholte Ausführung der Operationen durch Fill() und FillSchema()
		try {
			dbConnection.Open();
			dbAdapterCus.Fill(ds, "Customers");
			dbAdapterOrd.Fill(ds, "Orders");
			dbAdapterOrd.FillSchema(ds, SchemaType.Source);
		} finally {
			dbConnection.Close();
		}

		// Referenzvariablen für den einfachen Zugriff auf die Tabellen
		dtCustomers = ds.Tables["Customers"];
		dtOrders = ds.Tables["Orders"];
	}

	static void PrintData() {
		Console.WriteLine("Customers:\n{0,10} {1,40} {2,20}\n",
						  "CustomerID", "Company", "Country");
		for (int i = 0; i < 5; i++)
			Console.WriteLine("{0,10} {1,40} {2,20}", dtCustomers.Rows[i][0],
				dtCustomers.Rows[i][1], dtCustomers.Rows[i]["Country"]);
		Console.WriteLine("\n\nOrders:\n{0,10} {1,40}\n", "OrderID", "CustomerID");
		for (int i = 0; i < 5; i++)
			Console.WriteLine("{0,10} {1,40}", dtOrders.Rows[i][0],
				dtOrders.Rows[i][1]);
	}

	static void ChangeData() {
		dtCustomers.Rows[0]["Country"] = "Lummerland";
		dtOrders.Rows[0]["CustomerID"] = "TOMSP";
	}

	static void UpdateData() {
		using SqlConnection dbConnection = new(cs);
		using SqlCommand selCommandCus = new(selCus, dbConnection);
		using SqlCommand selCommandOrd = new(selOrd, dbConnection);
		using SqlDataAdapter dbAdapterCus = new(selCommandCus);
		using SqlDataAdapter dbAdapterOrd = new(selCommandOrd);

		// DML-Kommandos für beide DbDataAdapter automatisch erstellen lassen
		new SqlCommandBuilder(dbAdapterCus);
		new SqlCommandBuilder(dbAdapterOrd);

		try {
			dbConnection.Open();
			dbAdapterCus.Update(dtCustomers);
			dbAdapterOrd.Update(dtOrders);
		} finally {
			dbConnection.Close();
		}
	}

	static void Main() {
		ReadData(cs, selCus, selOrd);
		Console.WriteLine("Ausgangszustand:\n");
		PrintData();
		Console.WriteLine("\nWeiter mit Enter"); Console.ReadLine();
		ChangeData();
		Console.WriteLine("Nach der Änderung:\n");
		PrintData();
		UpdateData();
	}
}
