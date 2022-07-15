using System;
using System.Data.SqlClient;

class DataReaderDemo {
	static void Main() {
		SqlConnection dbConnection = new SqlConnection();
		dbConnection.ConnectionString =
			@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Data\NORTHWND.MDF;" +
			@"Integrated Security=True;User Instance=True";

		// SQL-Kommando erstellen:
		SqlCommand command = new SqlCommand("SELECT CompanyName FROM Customers", dbConnection);

		// Verbindung zur Datenbank �ffnen:
		dbConnection.Open();

		// Zu SqlDataReader ex. kein �ffentl. Konstruktor.
		// Die Methode SqlCommand.ExecuteReader() liefert das Objekt:
		SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
		
		while (reader.Read()) {
			Console.WriteLine(reader["CompanyName"]);
		}

		// Das Schlie�en des Readers gibt das Connection-Objekt f�r eine andere Verwendung frei:
		reader.Close();
		// Schlie�en der Datenbankverbindung:
		dbConnection.Close();
		Console.ReadLine();
	}
}