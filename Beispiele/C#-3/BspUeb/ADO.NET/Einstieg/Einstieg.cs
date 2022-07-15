using System;
using System.Data;
using System.Data.SqlClient;

class AdoNetEinstieg {
	SqlConnection dbConnection = new SqlConnection();
	SqlCommand selCommand;
	SqlDataAdapter dbAdapter = new SqlDataAdapter();
	DataSet ds = new DataSet();
	DataTable dt;

	AdoNetEinstieg() {
		// Dateizugriff über SQL Server - Benutzerinstanz
		dbConnection.ConnectionString = @"Data Source=(local)\SQLEXPRESS;" +
			@"AttachDbFilename=E:\Data\NORTHWND.MDF;" +
			"Integrated Security=True;User Instance=True";

		// TCP-Zugriff
		//dbConnection.ConnectionString = "Data Source=tcp:bernhard\\SQLEXPRESS;" +
		//    "Database=Northwind;Integrated Security=True;Connection Timeout=3";

		selCommand = new SqlCommand("SELECT EmployeeID,FirstName,LastName FROM Employees", dbConnection);
		dbAdapter.SelectCommand = selCommand;

		dbAdapter.TableMappings.Add("Table", "Employees");
		
		try {
			dbConnection.Open(); // Vermeidet zweimaliges Öffnen und Schließen durch Fill() und FillSchema()
			dbAdapter.Fill(ds);
			dbAdapter.FillSchema(ds, SchemaType.Mapped);
		} finally {
			dbConnection.Close();
		}
		dt = ds.Tables["Employees"];
	}

	void PrintData() {
		for (int i = 0; i < dt.Rows.Count; i++) {
			for (int j = 0; j < dt.Columns.Count; j++)
				Console.Write("{0,15}", dt.Rows[i][j]);
			Console.WriteLine();
		}
	}

	static void Main() {
		AdoNetEinstieg dsd = new AdoNetEinstieg();
		dsd.PrintData();
		Console.ReadLine();
	}
}