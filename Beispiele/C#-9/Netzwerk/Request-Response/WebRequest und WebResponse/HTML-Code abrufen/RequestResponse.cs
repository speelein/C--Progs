using System;
using System.IO;
using System.Net;
using System.Text;

class RequestResponse {
	static void Main() {
		// Request-Objekt zu einem URI erzeugen
		WebRequest request = WebRequest.Create("https://www.uni-trier.de/");

		// Protokollspezifische Request-Konfiguration
		((HttpWebRequest)request).UserAgent =
		  "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:89.0) " +
		  "Gecko/20100101 Firefox/89.0";

		// Response anfordern
		using (WebResponse response = request.GetResponse()) {
			// Zugriff auf Metainformation
			Console.WriteLine("Letzte Änderung:\t" +
				((HttpWebResponse)response).LastModified);
			Console.WriteLine("Zeichensatz:    \t" +
				((HttpWebResponse)response).CharacterSet);
			Console.WriteLine("Mit Enter weiter zum Inhhalt");
			Console.ReadLine();

			// Zugriff auf den Strom mit der Serverantwort
			using (Stream responseStream = response.GetResponseStream()) {
				// StreamReader mit passender Kodierung erstellen
				string cs = ((HttpWebResponse)response).CharacterSet.ToUpper();
				Encoding enc;
				switch (cs) {
					case "UTF-8":
					case "ISO-8859-1":
						enc = Encoding.GetEncoding(cs); break;
					default:
						enc = Encoding.Default; break;
				}
				using StreamReader reader = new(responseStream, enc);
				// 20 Zeilen der Serverantwort ausgeben
				string s;
				int i = 0;
				while ((s = reader.ReadLine()) != null)
					Console.WriteLine(s);
			}
		}
	}
}