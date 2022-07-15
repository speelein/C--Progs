using System;
using System.Data;
using System.Data.SqlClient;

class DataAdapterDemo {
	string cs = "Data Source=(LocalDb)\\MSSQLLocalDB; " +
				"Initial Catalog=Northwind; Integrated Security=true";
	string selCmd = "SELECT EmployeeID, FirstName, LastName FROM Employees";
	SqlDataAdapter dbAdapter = new();
	DataSet ds = new();
	DataTable dt;

	void GetData() {
		using SqlConnection dbConnection = new(cs);
		dbAdapter.SelectCommand = new(selCmd, dbConnection);
		//dbAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

		dbConnection.Open(); // Vermeidet zweimaliges ÷ffnen und Schlieﬂen durch Fill() und FillSchema()
		dbAdapter.Fill(ds, "Employees");
		dt = ds.Tables["Employees"];
		dbAdapter.FillSchema(dt, SchemaType.Source);
		//Console.WriteLine("AutoIncrement(EmployeeID) = " + dt.Columns["EmployeeID"].AutoIncrement);
	}

	void PrintData() {
		for (int i = 0; i < dt.Rows.Count; i++) {
			for (int j = 0; j < dt.Columns.Count; j++)
				Console.Write("{0,15}", dt.Rows[i][j]);
			Console.WriteLine();
		}
	}

	void AddData() {
		DataRow dr = dt.NewRow();
		dr["FirstName"] = "First";
		dr["LastName"] = "Last";
		dt.Rows.Add(dr);
	}

	void ChangeData() {
		DataRow dr = dt.NewRow();
		foreach (DataRow row in dt.Rows)
			if (row["LastName"].ToString() == "Last")
				row["LastName"] = "Laster";
	}

	void UpdateData() {
		using SqlConnection dbConnection = new(cs);
		dbAdapter.SelectCommand = new(selCmd, dbConnection);
		new SqlCommandBuilder(dbAdapter);
		dbAdapter.Update(dt);
	}

	static void Main() {
		DataAdapterDemo updateDemo = new DataAdapterDemo();
		updateDemo.GetData();
		updateDemo.PrintData();
		Console.ReadLine();

		updateDemo.AddData();
		updateDemo.PrintData();
		Console.ReadLine();

		updateDemo.ChangeData();
		updateDemo.PrintData();

		updateDemo.UpdateData();
		Console.ReadLine();
	}
}