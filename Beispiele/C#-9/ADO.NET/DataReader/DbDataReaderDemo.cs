using System;
using System.Data.SqlClient;
using System.Data;

class DbDataReaderDemo {
	static void Main() {
		using SqlConnection dbConnection = new("Data Source=(LocalDb)\\MSSQLLocalDB; " +
			"Initial Catalog=Northwind; Integrated Security=true");
		SqlCommand command = new("SELECT CompanyName FROM Customers", dbConnection);

		// ExecuteReader benötigt eine offene Verbindung.
		dbConnection.Open();
		// Zu SqlDataReader ex. kein öffentl. Konstruktor.
		// Die Methode SqlCommand.ExecuteReader() liefert das Objekt:
		Console.WriteLine("\nNorthwind-Kunden:");
		using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
			while (reader.Read()) {
				Console.WriteLine(" " + reader["CompanyName"]);
			}

		// Beim Schließen des Readers wird die Verbindung automatisch ebenfalls geschlossen.
		Console.WriteLine("\nVerbindung: " + dbConnection.State);
	}
}