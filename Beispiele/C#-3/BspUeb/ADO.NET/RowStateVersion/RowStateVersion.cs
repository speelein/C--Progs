using System;
using System.Data;
using System.Data.SqlClient;

class RowStateVersion {

	static void Main() {
		DataSet ds = new DataSet();
		SqlConnection dbConnection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;" +
			@"AttachDbFilename=E:\Data\NORTHWND.MDF;" +
			"Integrated Security=True;User Instance=True");
		SqlCommand selCommand = new SqlCommand(
			"SELECT CustomerID, CompanyName FROM Customers;", dbConnection);
		SqlDataAdapter dbAdapter = new SqlDataAdapter(selCommand);
		dbAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
		dbAdapter.Fill(ds);

		DataTable dt = ds.Tables["Table"];
		DataRow dr0 = dt.Rows[0];

		Console.WriteLine("RowStateVersion-Demo\n");
		Console.WriteLine("Nach Fill():\t\t" + dr0[0] + " " + dr0[1] + "\tRowState: " + dr0.RowState);

		dr0.BeginEdit();
		dr0[1] = "Alfreds Hummerkiste";
		Console.WriteLine("Geänd. im Bearb.mod.:\t" + dr0[0] + " " + dr0[1] + "\tRowState: " + dr0.RowState);
		Console.WriteLine(" Original-Vers.:\t" + dr0[0, DataRowVersion.Original] + " " + dr0[1, DataRowVersion.Original]);
		Console.WriteLine(" Proposed-Vers.:\t" + dr0[0, DataRowVersion.Proposed] + " " + dr0[1, DataRowVersion.Proposed]);
		dr0.CancelEdit();
		Console.WriteLine("Nach CancelEdit():\t" + dr0[0] + " " + dr0[1] + "\tRowState: " + dr0.RowState);

		dr0[1] = "Alfreds Hummerkiste";
		Console.WriteLine("\nNach Änderung:\t\t" + dr0[0] + " " + dr0[1] + "\tRowState: " + dr0.RowState);
		Console.WriteLine(" Original-Vers.:\t" + dr0[0, DataRowVersion.Original] + " " + dr0[1, DataRowVersion.Original]);

		dt.AcceptChanges();
		Console.WriteLine("Nach AcceptChanges():\t" + dr0[0] + " " + dr0[1] + "\tRowState: " + dr0.RowState);
		Console.WriteLine(" Original-Vers.:\t" + dr0[0, DataRowVersion.Original] + " " + dr0[1, DataRowVersion.Original]);

		DataRow dn = dt.NewRow();
		dn["CustomerID"] = "NEWK2";
		dn["CompanyName"] = "Rempremerding";
		Console.WriteLine("\nNach NewRow():\t\t" + dn[0] + " " + dn[1] + "\tRowState: " + dn.RowState);
		Console.WriteLine(" Current:\t" + dn.HasVersion(DataRowVersion.Current) + "\n Default:\t" + dn.HasVersion(DataRowVersion.Default) +
			"\n Original:\t" + dn.HasVersion(DataRowVersion.Original) + "\n Proposed:\t" + dn.HasVersion(DataRowVersion.Proposed));
		dt.Rows.Add(dn);
		Console.WriteLine("Nach Add():\t\t" + dn[0] + " " + dn[1] + "\tRowState: " + dn.RowState);
		Console.WriteLine(" Current:\t" + dn.HasVersion(DataRowVersion.Current) + "\n Default:\t" + dn.HasVersion(DataRowVersion.Default) +
			"\n Original:\t" + dn.HasVersion(DataRowVersion.Original) + "\n Proposed:\t" + dn.HasVersion(DataRowVersion.Proposed));

		dt.RejectChanges();
		Console.WriteLine("Nach RejectChanges(): RowState: " + dn.RowState);

		DataRow dr2 = dt.Rows[2];
		dr2.Delete();
		Console.WriteLine("\nNach Delete():\t\t(Die Daten sind unzugänglich.)\tRowState: " + dr2.RowState);
		dr2.RejectChanges();
		Console.WriteLine("Nach RejectChanges():\t" + dr2[0] + " " + dr2[1] + "\tRowState: " + dr2.RowState);
		//dt.AcceptChanges();
		//Console.WriteLine("Nach AcceptChanges():\t(Die Daten sind verloren.)\tRowState: " + dr1.RowState);

		Console.ReadLine();
	}
}