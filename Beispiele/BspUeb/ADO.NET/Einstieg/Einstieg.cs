using System;
using System.Data;
using System.Data.SqlClient;
//using System.Configuration;

class AdoNetEinstieg {
	SqlConnection dbConnection = new SqlConnection();
	SqlCommand selCommand;
	SqlDataAdapter dbAdapter = new SqlDataAdapter();
	DataSet ds = new DataSet();
	DataTable dt;

	public AdoNetEinstieg() {
		dbConnection.ConnectionString = @"Data Source=(local)\SQLEXPRESS;" +
			@"AttachDbFilename=E:\Data\NORTHWND.MDF;" +
			"Integrated Security=True;User Instance=True";
		selCommand = new SqlCommand("SELECT EmployeeID,FirstName,LastName FROM Employees",
			dbConnection);
		dbAdapter.SelectCommand = selCommand;

		dbAdapter.TableMappings.Add("Table", "Employees");
		//Console.WriteLine("Mappings:");
		//for (int i = 0; i < dbAdapter.TableMappings.Count; i++) {
		//  Console.WriteLine(" " + dbAdapter.TableMappings[i].ToString() + " = " +
		//    dbAdapter.TableMappings[i].DataSetTable.ToString());
		//}
		
		try {
			dbConnection.Open(); // Vermeidet zweimaliges Öffnen und Schließen durch Fill() und FillSchema()
			dbAdapter.Fill(ds);
			dbAdapter.FillSchema(ds, SchemaType.Mapped);
		} finally {
			dbConnection.Close();
		}

		dt = ds.Tables["Employees"];
		//Console.WriteLine("MaxLength(FirstName) = " + dt.Columns["FirstName"].MaxLength + "\n");

		SqlCommandBuilder cb = new SqlCommandBuilder(dbAdapter);

		// ConnectionString für Zugriff via TCP/IP
		// dbConnection.ConnectionString = @"Server=tcp:BBGVM01\SQLEXPRESS;"+
		//	"Database=Northwind;Integrated Security=True";

		// Zugriff auf den ConnectionString per ConfigurationManager
		// dbConnection.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString; 


		// Weiteres Abfrageergebnis anfordern:
		//selCommand.CommandText = "SELECT ProductID, ProductName FROM Products";
		//dbAdapter.Fill(ds, "Artikel");

		// Zugiff auf SqlConnection-Eigenschaften:
		//dbConnection.Open();
		//Console.WriteLine("Status: {0}", dbConnection.State);
		//Console.WriteLine("ServerVersion: {0}", dbConnection.ServerVersion);
		//Console.WriteLine("DataSource: {0}", dbConnection.DataSource);
		//Console.WriteLine("DataBase: {0}", dbConnection.Database);
		//dbConnection.Close();
	}

	public void PrintData() {
		for (int i = 0; i < dt.Rows.Count; i++) {
			for (int j = 0; j < dt.Columns.Count; j++)
				Console.Write("{0,15}", dt.Rows[i][j]);
			Console.WriteLine();
		}
	}

	public void ChangeData() {
		foreach (DataRow row in dt.Rows)
			if (row["LastName"].ToString() == "King")
				row["LastName"] = "Kong";
	}

	public void UpdateData() {
		dbAdapter.Update(ds, "Employees");
	}

	static void Main() {
		AdoNetEinstieg dsd = new AdoNetEinstieg();
		dsd.PrintData();
		Console.ReadLine();
		dsd.ChangeData();
		dsd.PrintData();
		dsd.UpdateData();
		Console.ReadLine();
	}
}