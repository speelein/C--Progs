using System;
using System.Data;
using System.Data.SqlClient;

class DataSetTableRowColumn {
    SqlConnection dbConnection;
	SqlCommand selCommandCust, selCommandOrd;
	SqlDataAdapter dbAdapterOrd, dbAdapterCust;
	DataSet ds = new DataSet();
	DataTable dtCustomers, dtOrders;
	DataRelation coRel;

	DataSetTableRowColumn() {
		dbConnection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;" +
			@"AttachDbFilename=E:\Data\NORTHWND.MDF;" +
			"Integrated Security=True;User Instance=True");

		selCommandCust = new SqlCommand(
			"SELECT CustomerID, CompanyName, Country FROM Customers", dbConnection);
		selCommandOrd = new SqlCommand(
			"SELECT OrderID, CustomerID, ShipCountry FROM Orders", dbConnection);

		dbAdapterCust = new SqlDataAdapter(selCommandCust);
		dbAdapterCust.TableMappings.Add("Table", "Customers");
		dbAdapterOrd = new SqlDataAdapter(selCommandOrd);
		dbAdapterOrd.TableMappings.Add("Table", "Orders");

		// Die Adapter werden angewiesen, Schema-Informationen zu übernehmen:
		dbAdapterCust.MissingSchemaAction = MissingSchemaAction.AddWithKey;
		dbAdapterOrd.MissingSchemaAction = MissingSchemaAction.AddWithKey;

		try {
			dbConnection.Open(); // Vermeidet zweimaliges Öffnen und Schließen durch Fill() und FillSchema()
			dbAdapterCust.Fill(ds);
			dbAdapterOrd.Fill(ds);
			// Alternativer Schema-Transfer:
			//dbAdapterCust.FillSchema(ds, SchemaType.Mapped);
			//dbAdapterOrd.FillSchema(ds, SchemaType.Mapped);
		} finally {
			dbConnection.Close();
		}
		
		dtCustomers = ds.Tables["Customers"];
		dtOrders = ds.Tables["Orders"];

		// DataTable-Ereignisse
		dtCustomers.RowChanging += CustomersOnRowChanging;
		dtCustomers.RowChanged += CustomersOnRowChanged;
		dtCustomers.ColumnChanged += CustomersOnColumnChanged;
		dtCustomers.ColumnChanging += CustomersOnColumnChanging;

		// Vereinbarung einer Master-Detail - Beziehung:
		DataColumn parent = dtCustomers.Columns["CustomerID"];
		DataColumn child = dtOrders.Columns["CustomerID"];
		ds.Relations.Add(new DataRelation("CustomersOrders", parent, child));
		coRel = ds.Relations["CustomersOrders"];

		// Der SqlCommandBuilder erstellt automatisch die vom DataAdapter benötigten SQL-Kommandos
		// zum Zum Aktualisieren der Datenbank. Wir ändern nur die Customers-Tabelle.
		new SqlCommandBuilder(dbAdapterCust);
	}

	void PrintDataCustomers() {
		Console.WriteLine("Die ersten 10 Fälle aus der Customers-Tabelle:\n");
		Console.WriteLine("{0,15} {1,40} {2,20}", "CustomerID", "CompanyName", "Country");
		Console.WriteLine("{0,15} {1,40} {2,20}\n", dtCustomers.Rows[0]["CustomerID"].GetType().ToString(),
			dtCustomers.Rows[0]["CompanyName"].GetType().ToString(),
			dtCustomers.Rows[0]["Country"].GetType().ToString());
		for (int i = 0; i < 10; i++)
			if (dtCustomers.Rows[i].RowState != DataRowState.Deleted)
				Console.WriteLine("{0,15} {1,40} {2,20}", dtCustomers.Rows[i][0],
					dtCustomers.Rows[i][1], dtCustomers.Rows[i]["Country"]);
		// Schema-Informationen
		Console.WriteLine("\nSchema-Informationen zur Customers-Tabelle:\n\nMaxLength(CompanyName)     = " + dtCustomers.Columns["CompanyName"].MaxLength +
			"\nPrimärschlüssel(Customers) = " + dtCustomers.PrimaryKey[0].ColumnName);
		foreach (Constraint c in dtCustomers.Constraints) {
			Console.WriteLine(c.ConstraintName + " " + c.Table.TableName + " " + c.GetType().ToString());
			if (c.GetType() == typeof(UniqueConstraint))
				Console.WriteLine(" Spalte zur UniqueConstraint: "+(c as UniqueConstraint).Columns[0].ColumnName);
		}
	}

	void PrintDataOrders() {
		Console.WriteLine("\n\nDie ersten 5 Fälle aus der Orders-Tabelle:\n");
		Console.WriteLine("{0,15} {1,15} {2,20}", "OrderID", "CustomerID", "ShipCountry");
		Console.WriteLine("{0,15} {1,15} {2,20}\n", dtOrders.Rows[0]["OrderID"].GetType().ToString(),
			dtOrders.Rows[0]["CustomerID"].GetType().ToString(),
			dtOrders.Rows[0]["ShipCountry"].GetType().ToString());
		for (int i = 0; i < 5; i++)
			Console.WriteLine("{0,15} {1,15} {2,20}", dtOrders.Rows[i][0],
				dtOrders.Rows[i][1], dtOrders.Rows[i]["ShipCountry"]);
		// Schema-Informationen
		Console.WriteLine("\nSchema-Informationen zur Orders-Tabelle:");
		foreach (Constraint c in dtOrders.Constraints) {
			Console.WriteLine(c.ConstraintName + " " + c.Table.TableName + " " + c.GetType().ToString());
			if (c.GetType() == typeof(UniqueConstraint))
				Console.WriteLine(" Spalte zur UniqueConstraint: " + (c as UniqueConstraint).Columns[0].ColumnName);
		}
	}

	void PrintMasterDetailConstraints() {
		Console.WriteLine("\n\nAus der Master-Details-Beziehung resultierende Constaints:");
		Console.WriteLine("\nParentKeyConstraint zur Beziehung \"CustomersOrders\":" +
			"\n Tabelle: " + coRel.ParentKeyConstraint.Table.TableName +
			"\n Feld:    " + coRel.ParentKeyConstraint.Columns[0].ColumnName +
			"\n Typ:     " + coRel.ParentKeyConstraint.GetType());
		Console.WriteLine("\nChildKeyConstraint zur Beziehung \"CustomersOrders\":" +
			"\n Tabelle: " + coRel.ChildKeyConstraint.Table.TableName +
			"\n Feld:    " + coRel.ChildKeyConstraint.Columns[0].ColumnName +
			"\n Typ:     " + coRel.ChildKeyConstraint.GetType());
	}

	void PrintCustomerChildRows() {
		DataRow[] crs;
		Console.WriteLine("\n\nDie ersten beiden Fälle aus der Customers-Tabelle mit zugeh. Bestellungen:");
		for (int i = 0; i < 2; i++)
			if (dtCustomers.Rows[i].RowState != DataRowState.Deleted) {
				Console.WriteLine("\nCustomerID: " + dtCustomers.Rows[i][0] + "  CompanyName: " + dtCustomers.Rows[i][1]);
				crs = dtCustomers.Rows[i].GetChildRows(ds.Relations["CustomersOrders"]);
				foreach(DataRow dr in crs)
					Console.WriteLine("   OrderID: "+dr["OrderID"]+"  ShipCountry: "+ dr["ShipCountry"]);
			}
	}

	void ChangeData() {
		// Einzelne Werte ändern
		//DataRow dr = dtCustomers.Rows[0];
		DataRow dr = dtCustomers.Rows.Find("ALFKI");

		Console.WriteLine("\nVor BeginEdit");
		dr.BeginEdit();
		dr["CompanyName"] = "Alfreds Futterkiste";
		dr["Country"] = "Hummerland";
		//dr["Country"] = null;
		//dr.ItemArray = new Object[] {null, "Alfreds Fuderkiste", null};
		//dr["Country"] = DBNull.Value;
		//dr.CancelEdit();
		Console.WriteLine("Vor End- bzw. CancelEdit");
		if (dr.HasErrors == false)
			dr.EndEdit();
		else
			dr.CancelEdit();
		Console.WriteLine("Nach End- bzw. CancelEdit\n");

		// Zeile löschen oder ergänzen
		DataRow drem = dtCustomers.Rows.Find("BONAS");
		if (drem != null)
			drem.Delete();
			//dtCustomers.Rows.Remove(drem); // führt nicht zum Löschen der zugeh. Datenbankzeile beim Update() 
		else {
			drem = dtCustomers.NewRow(); // neue Zeile mit dem dtCustomers-Schema erstellen
			drem["CustomerID"] = "BONAS";
			drem["CompanyName"] = "Bonner Assekuranz";
			drem["Country"] = "Germany";
			dtCustomers.Rows.Add(drem);  // Zeile in die Tabelle dtCustomers aufnehmen
		}
	}

	void CustomersOnRowChanging(Object sender,DataRowChangeEventArgs e) {
		DataTable table = (DataTable)sender;
		if (e.Row.HasVersion(DataRowVersion.Current))
			Console.WriteLine("RowChanging (ID: " + e.Row.ItemArray[0].ToString() +
				"), Action: " + e.Action.ToString() + ", RowState: " + e.Row.RowState);
		else
			Console.WriteLine("RowChanging, Action: " + e.Action.ToString());
	}

	void CustomersOnRowChanged(Object sender, DataRowChangeEventArgs e) {
		DataTable table = (DataTable)sender;
		if (e.Row.HasVersion(DataRowVersion.Current))
			Console.WriteLine("RowChanged (ID: " + e.Row.ItemArray[0].ToString() +
				"), Action: " + e.Action.ToString() + ", RowState: " + e.Row.RowState);
		else
			Console.WriteLine("RowChanged, Action: " + e.Action.ToString());
	}

	void CustomersOnColumnChanging(Object sender, DataColumnChangeEventArgs e) {
		DataTable table = (DataTable)sender;
		Console.WriteLine("ColumnChanging,\tSpalte: " + e.Column.Caption.ToString() +
			"\n  ProposedValue: " + e.ProposedValue + ", Wert: " + e.Row[e.Column].ToString());
		if (e.Column.ToString().Equals("Country"))
			if ((e.ProposedValue as String).Equals("Kummerland"))
				e.Row.SetColumnError(e.Column, "Error");
				//e.ProposedValue = e.Row[e.Column];
	}

	void CustomersOnColumnChanged(Object sender, DataColumnChangeEventArgs e) {
		DataTable table = (DataTable)sender;
		Console.WriteLine("ColumnChanged,\tSpalte: " + e.Column.Caption.ToString() +
			"\n  ProposedValue: " + e.ProposedValue + ", Wert: " + e.Row[e.Column].ToString());
	}
	
	void UpdateData() {
		dbAdapterCust.Update(dtCustomers);
	}

	static void Main() {
		DataSetTableRowColumn ssd = new DataSetTableRowColumn();
		ssd.PrintDataCustomers();
		ssd.PrintDataOrders();
		ssd.PrintMasterDetailConstraints();
		ssd.PrintCustomerChildRows();
		ssd.ChangeData();
		ssd.UpdateData();
		Console.ReadLine();
	}
}