using System;
using System.Data.SqlClient;

class DataReaderDemo {
	static void Main() {
		SqlConnection dbConnector = new SqlConnection();
		dbConnector.ConnectionString =
			@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Data\NORTHWND.MDF;" +
			@"Integrated Security=True;User Instance=True";

		// SQL-Kommando erstellen
		String strSqlCmd = "SELECT CompanyName FROM Customers";
		SqlCommand command = new SqlCommand(strSqlCmd, dbConnector);

		// Verbindung zur Datenbank �ffnen
		dbConnector.Open();

		// Zu SqlDataReader ex. kein �ffentl. Konstruktor!
		// SqlCommand.ExecuteReader() liefert das Objekt
		SqlDataReader reader = command.ExecuteReader();
		
		while (reader.Read()) {
			Console.WriteLine(reader["CompanyName"]);
		}

		// Schlie�en des Readers gibt das Connection-Objekt f�r eine andere Verwendung frei:
		reader.Close();
		// Schlie�en der Datenbankverbindung:
		dbConnector.Close();
		Console.ReadLine();
	}
}