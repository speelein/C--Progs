using System;
using System.Data;
using System.Data.SqlClient;

class Disconnected {
	SqlConnection dbConnection = new SqlConnection();
	SqlCommand selCommandCus, selCommandOrd;
	SqlDataAdapter dbAdapterCus, dbAdapterOrd;
	DataSet ds = new DataSet();
	DataTable dtCustomers, dtOrders;

	public Disconnected() {
		dbConnection.ConnectionString = @"Data Source=(local)\SQLEXPRESS;" +
			@"AttachDbFilename=E:\Data\NORTHWND.MDF;" +
			"Integrated Security=True;User Instance=True";
		selCommandCus = new SqlCommand(
			"SELECT CustomerID, CompanyName, Country FROM Customers", dbConnection);
		selCommandOrd = new SqlCommand(
			"SELECT OrderID, CustomerID, ShipCountry FROM Orders", dbConnection);
		dbAdapterCus =  new SqlDataAdapter(selCommandCus);
		dbAdapterOrd =  new SqlDataAdapter(selCommandOrd);

		new SqlCommandBuilder(dbAdapterCus);
		new SqlCommandBuilder(dbAdapterOrd);

		dbAdapterCus.TableMappings.Add("Table", "Customers");
		dbAdapterOrd.TableMappings.Add("Table", "Orders");

		try {
			dbConnection.Open();
			dbAdapterCus.Fill(ds);
			dbAdapterCus.FillSchema(ds, SchemaType.Mapped);
			dbAdapterOrd.Fill(ds);
			dbAdapterOrd.FillSchema(ds, SchemaType.Mapped);
		} finally {
			dbConnection.Close();
		}

		dtCustomers = ds.Tables["Customers"];
		dtOrders = ds.Tables["Orders"];

		DataColumn parent = dtCustomers.Columns["CustomerID"];
		DataColumn child = dtOrders.Columns["CustomerID"];
		ds.Relations.Add(new DataRelation("CustomersOrders", parent, child));

		//DataRelation co = ds.Relations["CustomersOrders"];
		//Console.WriteLine("\nParentKeyConstraint zur Beziehung \"CustomersOrders\":" +
		//  "\n Tabelle: " + co.ParentKeyConstraint.Table.TableName +
		//  "\n Feld:    " + co.ParentKeyConstraint.Columns[0].ColumnName +
		//  "\n Typ:     " + co.ParentKeyConstraint.GetType().ToString());
		//Console.WriteLine("\nChildKeyConstraint zur Beziehung \"CustomersOrders\":" +
		//  "\n Tabelle: " + co.ChildKeyConstraint.Table.TableName +
		//  "\n Feld:    " + co.ChildKeyConstraint.Columns[0].ColumnName +
		//  "\n Typ:     " + co.ChildKeyConstraint.GetType().ToString());
	}

	public void PrintData() {
		Console.WriteLine("{0,10} {1,40} {2,20}\n", "CustomerID", "Company", "Country");
		for (int i = 0; i < 5; i++)
			Console.WriteLine("{0,10} {1,40} {2,20}", dtCustomers.Rows[i][0],
				dtCustomers.Rows[i][1], dtCustomers.Rows[i]["Country"]);
		Console.WriteLine("\n\n{0,10} {1,40}\n", "OrderID", "CustomerID");
		for (int i = 0; i < 5; i++)
			Console.WriteLine("{0,10} {1,40}", dtOrders.Rows[i][0],
				dtOrders.Rows[i][1]);
	}

	public void ChangeData() {
		dtCustomers.Rows[0]["Country"] = "Lummerland";
		dtOrders.Rows[0]["CustomerID"] = "TOMSP";
	}

	public void UpdateData() {
		try {
			dbConnection.Open();
			dbAdapterCus.Update(ds);
			dbAdapterOrd.Update(ds);
		} finally {
			dbConnection.Close();
		}
	}

	static void Main() {
		Disconnected dsd = new Disconnected();
		dsd.PrintData();
		Console.ReadLine();
		dsd.ChangeData();
		dsd.PrintData();
		dsd.UpdateData();
		Console.ReadLine();
	}
}