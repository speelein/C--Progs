using System;
using System.Collections.Generic;
using System.Text;

class ListSetContainsTest {
	const int ANZ = 20_000;

	static void TestCollection(ICollection<String> collection) {
		var sb = new StringBuilder();
		Random ran = new Random();

        // Füllen
        Console.WriteLine("\nKollektionsklasse:\t\t\t" + collection.GetType().Name);
		long start = DateTime.Now.Ticks;
		for (int i = 0; i < ANZ; i++) {
			sb.Clear();
			for (int j = 0; j < 5; j++)
				sb.Append((char)(65 + ran.Next(26)));
			collection.Add(sb.ToString());
		}
		Console.WriteLine(" Zeit zum Füllen:\t\t\t {0:F1} Millisek.", (DateTime.Now.Ticks - start) / 1.0e4);

		// Existenzprüfung
		start = DateTime.Now.Ticks;
		for (int i = 0; i < ANZ; i++) {
			sb.Clear();
			for (int j = 0; j < 5; j++)
				sb.Append((char)(65 + ran.Next(26)));
			collection.Contains(sb.ToString());
		}
		Console.WriteLine(" Zeit für die Existenzprüfungen:\t {0:F1} Millisek.", (DateTime.Now.Ticks - start) / 1.0e4);
	}

	public static void Main() {
		// Zeitmessung vorbereiten
		long wzeit = DateTime.Now.Ticks;

		Console.WriteLine("Performanzuntersuchung zu List- und Set-Typen bei Existenzprüfungen");
		TestCollection(new List<String>());
		TestCollection(new LinkedList<String>());
		TestCollection(new HashSet<String>());
        TestCollection(new SortedSet<String>());
    }
}
