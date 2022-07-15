using System;
using System.Data;
using System.Data.SqlClient;

class UpdateDemo {
	SqlConnection dbConnection = new SqlConnection();
	SqlCommand selCommand;
	SqlDataAdapter dbAdapter = new SqlDataAdapter();
	DataSet ds = new DataSet();
	DataTable dt;

	UpdateDemo() {
		dbConnection.ConnectionString = @"Data Source=(local)\SQLEXPRESS;" +
			@"AttachDbFilename=E:\Data\NORTHWND.MDF;" +
			"Integrated Security=True;User Instance=True";
		selCommand = new SqlCommand("SELECT EmployeeID,FirstName,LastName FROM Employees",
			dbConnection);
		dbAdapter.SelectCommand = selCommand;

		dbAdapter.TableMappings.Add("Table", "Employees");

		try	{
			dbConnection.Open(); // Vermeidet zweimaliges ÷ffnen und Schlieﬂen durch Fill() und FillSchema()
			dbAdapter.Fill(ds);
			dbAdapter.FillSchema(ds, SchemaType.Mapped);
		} finally {
			dbConnection.Close();
		}

		dt = ds.Tables["Employees"];
		SqlCommandBuilder cb = new SqlCommandBuilder(dbAdapter);
	}

	void PrintData() {
		for (int i = 0; i < dt.Rows.Count; i++)	{
			for (int j = 0; j < dt.Columns.Count; j++)
				Console.Write("{0,15}", dt.Rows[i][j]);
			Console.WriteLine();
		}
	}

	void ChangeData() {
		foreach (DataRow row in dt.Rows)
			if (row["LastName"].ToString() == "Brgel")
				row["LastName"] = "Rempremerding";
	}

	void UpdateData() {
		dbAdapter.Update(ds, "Employees");
	}

	static void Main(){
		UpdateDemo updateDemo = new UpdateDemo();
		updateDemo.PrintData();
		Console.ReadLine();
		updateDemo.ChangeData();
		updateDemo.PrintData();
		updateDemo.UpdateData();
		Console.ReadLine();
	}
}