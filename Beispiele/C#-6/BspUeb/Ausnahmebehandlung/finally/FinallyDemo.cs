using System;
using System.IO;

class FinallyDemo {
	static void Mean(String dateiname) {
		StreamReader sr = null;
		FileStream fs = null;
		try {
			fs = new FileStream(dateiname, FileMode.Open);
		} catch {
			Console.WriteLine("Fehler beim Öffnen der Datei {0}", dateiname);
			throw;
		} 
		try {
			String s;
			int n = 0;
			double summe = 0.0;
			sr = new StreamReader(fs);
			while ((s = sr.ReadLine()) != null) {
				summe += Convert.ToDouble(s);
				n++;
			}
			Console.WriteLine("Deskriptive Statistiken zur Datei {0}\n", dateiname);
			Console.WriteLine("Anzahl:\t" + n);
			Console.WriteLine("Summe:\t" + summe);
			Console.WriteLine("Mittel:\t" + summe / n);
		} catch {
			Console.WriteLine("Fehler beim Lesen der Datei {0}", dateiname);
			throw;
		} finally {
			sr.Close();
		}
	}

	static void Main() {
		try {
			Mean("daten.txt");
		} catch {
			Console.WriteLine("Fehler bei der Mittelwertsberechnung in der Methode Mean");
		}
		Console.Read();
	}
}