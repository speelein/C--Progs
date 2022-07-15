using System;
using System.Data;
using System.Data.SqlClient;

class Verbindungslos {
	SqlConnection dbConnection = new SqlConnection();
	SqlCommand selCommandCus, selCommandOrd;
	SqlDataAdapter dbAdapterCus, dbAdapterOrd;
	DataSet ds = new DataSet();
	DataTable dtCustomers, dtOrders;

	Verbindungslos() {
		dbConnection.ConnectionString = @"Data Source=(local)\SQLEXPRESS;" +
			@"AttachDbFilename=E:\Data\NORTHWND.MDF;" +
			"Integrated Security=True;User Instance=True";
		selCommandCus = new SqlCommand(
			"SELECT CustomerID, CompanyName, Country FROM Customers", dbConnection);
		selCommandOrd = new SqlCommand(
			"SELECT OrderID, CustomerID, ShipCountry FROM Orders", dbConnection);
		dbAdapterCus = new SqlDataAdapter(selCommandCus);
		dbAdapterOrd = new SqlDataAdapter(selCommandOrd);

		// DML-Kommandos für beide DataAdapter automatisch erstellen lassen
		new SqlCommandBuilder(dbAdapterCus);
		new SqlCommandBuilder(dbAdapterOrd);

		// TableMappings erleichtern die Ansprache der Tabellen
		dbAdapterCus.TableMappings.Add("Table", "Customers");
		dbAdapterOrd.TableMappings.Add("Table", "Orders");

		// Das explizite Öffnen und Schließen der Datenbankverbindung vermeidet
		// die wiederholte Ausführung der Operationen durch Fill() und FillSchema()
		try {
			dbConnection.Open();
			dbAdapterCus.Fill(ds);
			dbAdapterCus.FillSchema(ds, SchemaType.Mapped);
			dbAdapterOrd.Fill(ds);
			dbAdapterOrd.FillSchema(ds, SchemaType.Mapped);
		}
		finally {
			dbConnection.Close();
		}

		// Referenzvariablen für den einfachen Zugriff auf die Tabellen
		dtCustomers = ds.Tables["Customers"];
		dtOrders = ds.Tables["Orders"];
	}

	void PrintData() {
		Console.WriteLine("Customers:\n{0,10} {1,40} {2,20}\n", "CustomerID", "Company", "Country");
		for (int i = 0; i < 5; i++)
			Console.WriteLine("{0,10} {1,40} {2,20}", dtCustomers.Rows[i][0],
				dtCustomers.Rows[i][1], dtCustomers.Rows[i]["Country"]);
		Console.WriteLine("\n\nOrders:\n{0,10} {1,40}\n", "OrderID", "CustomerID");
		for (int i = 0; i < 5; i++)
			Console.WriteLine("{0,10} {1,40}", dtOrders.Rows[i][0],
				dtOrders.Rows[i][1]);
	}

	void ChangeData() {
		dtCustomers.Rows[0]["Country"] = "Lummerland";
		dtOrders.Rows[0]["CustomerID"] = "TOMSP";
	}

	void UpdateData() {
		try {
			dbConnection.Open();
			dbAdapterCus.Update(ds);
			dbAdapterOrd.Update(ds);
		}
		finally {
			dbConnection.Close();
		}
	}

	static void Main() {
		Verbindungslos dsd = new Verbindungslos();
		Console.WriteLine("Ausgangszustand:\n");
		dsd.PrintData();
		Console.ReadLine();
		dsd.ChangeData();
		Console.WriteLine("Nach der Änderung:\n");		
		dsd.PrintData();
		dsd.UpdateData();
		Console.ReadLine();
	}
}