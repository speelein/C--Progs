using System;
using System.IO;

class FinallyDemo {
	static void Mean(String dateiname) {
        FileStream fs = null;
        try {
            fs = new FileStream(dateiname, FileMode.Open);
            String s;
            int n = 0;
            double summe = 0.0;
            StreamReader sr = new StreamReader(fs);
            while ((s = sr.ReadLine()) != null) {
                summe += Convert.ToDouble(s);
                n++;
            }
            Console.WriteLine($"Deskriptive Statistiken zur Datei {dateiname}\n");
            Console.WriteLine($"Anzahl:\t{n}");
            Console.WriteLine($"Summe:\t{summe}");
            Console.WriteLine($"Mittel:\t{summe / n}");
        } catch (Exception ex) {
            Console.WriteLine($"Fehler in Mean() beim Lesen der Datei {dateiname}\n{ex}\n");
            throw;
        } finally {
            if (fs != null)
                fs.Dispose();
        }
    }

	static void Main() {
		try {
            Mean(AppDomain.CurrentDomain.BaseDirectory+"daten.txt");
		} catch {
			Console.WriteLine("Fehler bei der Mittelwertsberechnung");
		}
	}
}