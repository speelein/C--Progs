using System;
using System.Data;
using System.Data.SqlClient;

class CommandDemo {
	SqlConnection dbConnection = new SqlConnection();
	SqlCommand selAvg, selAvgSupp;

	public CommandDemo() {
		dbConnection.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Data\NORTHWND.MDF;" +
			"Integrated Security=True;User Instance=True";
		selAvg = new SqlCommand("SELECT AVG(UnitPrice) FROM Products", dbConnection);
		selAvgSupp = new SqlCommand("SELECT AVG(UnitPrice) FROM Products WHERE SupplierID = @SuppID", dbConnection);
		selAvgSupp.Parameters.Add("@SuppID", SqlDbType.Int);
	}

	public void AvgPrice() {
		dbConnection.Open();
		Console.WriteLine("Mittlerer Preis aller Produkte: " + Convert.ToDouble(selAvg.ExecuteScalar()) + "\n");
		dbConnection.Close();
	}

	public void AvgPriceSupplier() {
		try {
			Console.Write("Nummer das Anbieters: ");
			int supp = Convert.ToInt32(Console.ReadLine());
			selAvgSupp.Parameters["@SuppID"].Value = supp;
			dbConnection.Open();
			Console.WriteLine("Mittlerer Preis aller Produkte von Anbieter " + supp + ": " +
				Convert.ToDouble(selAvgSupp.ExecuteScalar()));
		} catch {
		} finally {
			dbConnection.Close();
		}
	}

	static void Main() {
		CommandDemo cd = new CommandDemo();
		cd.AvgPrice();
		cd.AvgPriceSupplier();
		Console.ReadLine();
	}
}