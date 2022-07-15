using System;
using System.Data;
using System.Data.SqlClient;

class DataSetTableRowColumn {
	static DataSet ds = new();
	static DataTable dtCustomers, dtOrders;
	static DataRelation coRel;
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

		// Die Adapter werden angewiesen, beim Fill() - Aufruf Schema-Informationen zu übernehmen:
		dbAdapterCus.MissingSchemaAction = MissingSchemaAction.AddWithKey;
		dbAdapterOrd.MissingSchemaAction = MissingSchemaAction.AddWithKey;

		try {
			dbConnection.Open(); // Vermeidet zweimaliges Öffnen und Schließen durch Fill() und FillSchema()
			dbAdapterCus.Fill(ds, "Customers");
			dbAdapterOrd.Fill(ds, "Orders");
		} finally {
			dbConnection.Close();
		}
		
		dtCustomers = ds.Tables["Customers"];
		dtOrders = ds.Tables["Orders"];

        // DataTable-Ereignisse
        dtCustomers.ColumnChanging += CustomersOnColumnChanging;
        dtCustomers.ColumnChanged += CustomersOnColumnChanged;
        dtCustomers.RowChanging += CustomersOnRowChanging;
        dtCustomers.RowChanged += CustomersOnRowChanged;

        // Vereinbarung einer Master-Detail - Beziehung:
        DataColumn parent = dtCustomers.Columns["CustomerID"];
        DataColumn child = dtOrders.Columns["CustomerID"];
		coRel = new DataRelation("CustomersOrders", parent, child);
		ds.Relations.Add(coRel);

		// Das zur Beziehung erstellte ForeignKeyConstraint-Objekt hat für die Eigenschaft DeleteRule
		// den Wert Cascade, sodass beim Löschen der Master-Zeile auch die Details-Zeilen gelöscht werden.
		// Das widerspricht dem Verhalten der Datenbank, sodass mit dem alternativen Wert DeleteRule-None das
		// Löschen von Master-Zeilen verhindert werden sollte, wenn abhängige Details-Zeilen vorhanden sind.
		(coRel.ChildKeyConstraint as ForeignKeyConstraint).DeleteRule = Rule.None;
		//Console.WriteLine("\nDeletedRule = " + (coRel.ChildKeyConstraint as ForeignKeyConstraint).DeleteRule);

		// Eine analoge Aussage gilt für die Eigenschaft UpdateRule, sodass auch hier der 
		// alternative Wert None eingestellt werden sollte.
		(coRel.ChildKeyConstraint as ForeignKeyConstraint).UpdateRule = Rule.None;
	}

	static void PrintDataCustomers() {
		Console.WriteLine("Die ersten 10 Fälle aus der Customers-Tabelle:\n");
		Console.WriteLine("{0,15} {1,40} {2,20}", "CustomerID", "CompanyName", "Country");
		Console.WriteLine("{0,15} {1,40} {2,20}\n", dtCustomers.Rows[0]["CustomerID"].GetType(),
			dtCustomers.Rows[0]["CompanyName"].GetType(),
			dtCustomers.Rows[0]["Country"].GetType());
		for (int i = 0; i < 10; i++)
			if (dtCustomers.Rows[i].RowState != DataRowState.Deleted)
				Console.WriteLine("{0,15} {1,40} {2,20}", dtCustomers.Rows[i][0],
					dtCustomers.Rows[i][1], dtCustomers.Rows[i]["Country"]);

		// Schema-Informationen zur Customers-Tabelle anzeigen
		Console.WriteLine("\nSchema-Informationen zur Customers-Tabelle:");
		// Spaltenattribute
		Console.WriteLine(" MaxLength(CompanyName)     = " + dtCustomers.Columns["CompanyName"].MaxLength +
			"\n Primärschlüssel(Customers) = " + dtCustomers.PrimaryKey[0].ColumnName);

		// Constraints zur Customers-Tabelle
		Console.WriteLine("\nConstaints zur Customers-Tabelle:");
		foreach (Constraint c in dtCustomers.Constraints) {
			Console.WriteLine(" " + c.ConstraintName + "   " + c.GetType());
			if (c.GetType() == typeof(UniqueConstraint))
				Console.WriteLine(" Spalte zur UniqueConstraint: " +
					              (c as UniqueConstraint).Columns[0].ColumnName);
		}
	}

	static void PrintDataOrders() {
		Console.WriteLine("\n\nDie ersten 5 Fälle aus der Orders-Tabelle:\n");
		Console.WriteLine("{0,15} {1,15} {2,20}", "OrderID", "CustomerID", "ShipCountry");
		Console.WriteLine("{0,15} {1,15} {2,20}\n", dtOrders.Rows[0]["OrderID"].GetType(),
			dtOrders.Rows[0]["CustomerID"].GetType(),
			dtOrders.Rows[0]["ShipCountry"].GetType());
		for (int i = 0; i < 5; i++)
			Console.WriteLine("{0,15} {1,15} {2,20}", dtOrders.Rows[i][0],
				dtOrders.Rows[i][1], dtOrders.Rows[i]["ShipCountry"]);

		// Constaints zur Orders-Tabelle
		Console.WriteLine("\nConstaints zur Orders-Tabelle:");
		foreach (Constraint c in dtOrders.Constraints) {
			Console.WriteLine(" " + c.ConstraintName + "   " + c.GetType());
			if (c.GetType() == typeof(UniqueConstraint))
				Console.WriteLine("  Spalte zur UniqueConstraint:          " + (c as UniqueConstraint).Columns[0].ColumnName);
			if (c.GetType() == typeof(ForeignKeyConstraint))
				Console.WriteLine("  Spalte zu einer ForeignKeyConstraint: " + (c as ForeignKeyConstraint).Columns[0].ColumnName);
		}
		//Console.WriteLine("\nds.Relations.Count: " + ds.Relations.Count);
	}

	static void PrintMasterDetailConstraints() {
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

	static void PrintCustomerChildRows() {
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

	static void ChangeData() {
		//DataRow dr = dtCustomers.Rows[0];
		DataRow dr = dtCustomers.Rows.Find("ALFKI");

		// Einzelne Werte ändern
		//Console.WriteLine("\nVor BeginEdit: " + dr["Country"]);
		dr.BeginEdit();
		dr["CompanyName"] = "Alfreds Kutterkiste";
		dr["Country"] = "Hummerland";
		//dr["Country"] = DBNull.Value;
		//Console.WriteLine("Vor End- bzw. CancelEdit: " + dr["Country"]);
		if (!dr.HasErrors)
		    dr.EndEdit();
		else
		    dr.CancelEdit();
		//Console.WriteLine("Nach End- bzw. CancelEdit: " + dr["Country"] + "\n");

		// Zeile löschen oder ergänzen
		DataRow drem = dtCustomers.Rows.Find("BONAS");
		if (drem != null) {
			drem.Delete();
		} else {
			drem = dtCustomers.NewRow(); // neue Zeile mit dem dtCustomers-Schema erstellen
			drem["CustomerID"] = "BONAS";
			drem["CompanyName"] = "Bonner Assekuranz";
			drem["Country"] = "Germany";
			dtCustomers.Rows.Add(drem);  // Zeile in die Tabelle dtCustomers aufnehmen
		}
	}

	static void CustomersOnColumnChanging(Object sender, DataColumnChangeEventArgs e) {
		DataTable table = (DataTable)sender;
		Console.WriteLine("\nColumnChanging,\tSpalte: " + e.Column.Caption +
			"\n  vorgeschl. Wert: " + e.ProposedValue + ", akt. Wert: " + e.Row[e.Column]);
		if (e.Column.ColumnName.Equals("Country"))
			if ((e.ProposedValue as string).Equals("Kummerland"))
				e.Row.SetColumnError(e.Column, "Error");
				//	e.ProposedValue = e.Row[e.Column];
	}

	static void CustomersOnColumnChanged(Object sender, DataColumnChangeEventArgs e) {
		DataTable table = (DataTable)sender;
		Console.WriteLine("\nColumnChanged,\tSpalte: " + e.Column.Caption +
			"\n  vorgeschl. Wert: " + e.ProposedValue + ", akt. Wert: " + e.Row[e.Column]);
	}

	static void CustomersOnRowChanging(Object sender, DataRowChangeEventArgs e) {
		DataTable table = (DataTable)sender;
		Console.WriteLine("\nRowChanging (ID: " + e.Row.ItemArray[0] +
			"), Action: " + e.Action + ", RowState: " + e.Row.RowState +
			"\n  CompanyName: " + e.Row["CompanyName"]);
	}

	static void CustomersOnRowChanged(Object sender, DataRowChangeEventArgs e) {
		DataTable table = (DataTable)sender;
		Console.WriteLine("\nRowChanged (ID: " + e.Row.ItemArray[0] +
			"), Action: " + e.Action + ", RowState: " + e.Row.RowState +
			"\n  CompanyName: " + e.Row["CompanyName"]);
	}

	static void ViolateCustOrdRel() {
		DataRow dr = dtCustomers.Rows.Find("ALFKI");
		//dr["CustomerID"] = "ALFKJ";
		dr.Delete();
	}

	static void UpdateData() {
		using SqlConnection dbConnection = new(cs);
		using SqlCommand selCommandCus = new(selCus, dbConnection);
		using SqlDataAdapter dbAdapterCus = new(selCommandCus);
		new SqlCommandBuilder(dbAdapterCus);
		dbAdapterCus.Update(dtCustomers);

		Console.WriteLine(dbAdapterCus.SelectCommand.CommandText);
	}

	static void Main() {
		ReadData(cs, selCus, selOrd);
		PrintDataCustomers();
        PrintDataOrders();
        PrintMasterDetailConstraints();
        PrintCustomerChildRows();
        ChangeData();
		//ViolateCustOrdRel();
		//foreach (var c in dtOrders.Constraints)
		//    Console.WriteLine((c as Constraint).GetType().ToString());

		// UpdateData() bewirkt wegen der DataSet-Änderungen durch ChangeData() einen Aufruf von AcceptChanges(),
		// der wiederum die DataRow-Ereignisse RowChanging und RowChanged auslöst. Die Behandlungsmethoden CustomersOnRowChanging()
		// und CustomersOnRowChanged() haben wegen der gelöschten Zeile einen Ausnahmefehler zur Folge:
		// DeletedRowInaccessibleException: Deleted row information cannot be accessed through the row.
		// Daher werden die Registrierungen der Ereignisbehandlungsmethoden aufgehoben:
		dtCustomers.RowChanging -= CustomersOnRowChanging;
        dtCustomers.RowChanged -= CustomersOnRowChanged;

        UpdateData();
    }
}