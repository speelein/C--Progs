using System;
using System.Data;
using System.Data.SqlServerCe;

class AdoNetEinstieg {
    SqlCeConnection dbConnection = new SqlCeConnection();
	SqlCeCommand selCommand;
	SqlCeDataAdapter dbAdapter = new SqlCeDataAdapter();
	DataSet ds = new DataSet();
	DataTable dt;

	AdoNetEinstieg() {
        dbConnection.ConnectionString = @"Data Source=E:\Data\Northwind.sdf";
        selCommand = new SqlCeCommand("SELECT \"Employee ID\",\"First Name\",\"Last Name\" FROM Employees",
			dbConnection);
		dbAdapter.SelectCommand = selCommand;
		dbAdapter.TableMappings.Add("Table", "Employees");
	
		try {
			dbConnection.Open(); // Vermeidet zweimaliges ÷ffnen und Schlieﬂen durch Fill() und FillSchema()
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