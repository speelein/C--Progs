using System;
using System.Data;
using System.Data.SqlClient;

class AdoNetEinstieg {
	static void Main() {
		string cs = @"Server=tcp:bernhard\SQLEXPRESS; " +
					"Initial Catalog=Northwind; Integrated Security=true";
		using SqlConnection dbConnection = new(cs);

        SqlCommand selCommand = new("SELECT EmployeeID, FirstName, LastName FROM Employees", dbConnection);

		SqlDataAdapter dbAdapter = new();
		dbAdapter.SelectCommand = selCommand;
		dbAdapter.TableMappings.Add("Table", "Employees");
		DataSet ds = new();

		try {
			dbConnection.Open(); // Vermeidet zweimaliges Öffnen und Schließen durch Fill() und FillSchema()
			dbAdapter.Fill(ds);
			dbAdapter.FillSchema(ds, SchemaType.Mapped);
		} catch (Exception ex) {
			Console.WriteLine(ex.Message);
			Environment.Exit(1);
		} finally {
			dbConnection.Close();
		}

		DataTable dt = ds.Tables["Employees"];
		for (int i = 0; i < dt.Rows.Count; i++) {
			for (int j = 0; j < dt.Columns.Count; j++)
				Console.Write("{0,15}", dt.Rows[i][j]);
			Console.WriteLine();
		}
	}
}