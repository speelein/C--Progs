using System;
using System.IO;
using System.Net;
using System.Text;

class RequestRespone {
	static void Main() {
		// Request-Objekt zu URI erzeugen
		WebRequest request = WebRequest.Create("http://www.uni-trier.de/");

		// Protokollspezifische Request-Konfiguration
		((HttpWebRequest)request).UserAgent =
            "Mozilla/5.0 (Windows; U; Windows NT 5.1; de; rv:1.8.1.1) "+
            "Gecko/20061204 Firefox/2.0.0.1";

		// Response anfordern
		WebResponse response = request.GetResponse();

		// Zugriff auf Metainformation
		Console.WriteLine("Letzte Änderung:\t"+
            ((HttpWebResponse)response).LastModified);
        Console.WriteLine("Zeichensatz:    \t" +
            ((HttpWebResponse)response).CharacterSet);
        Console.ReadLine();

		// Zugriff auf den Strom mit der Serverantwort
		Stream content = response.GetResponseStream();

        // StreamReader mit passender Kodierung erstellen
        StreamReader reader;
        String cs = (((HttpWebResponse)response).CharacterSet).ToLower();
        switch (cs) {
            case "iso-8859-1":
            case "utf-8": reader = new StreamReader(content, Encoding.GetEncoding(cs));
                break;
            default: reader = new StreamReader(content);
                break;
        }

        // Serverantwort zeilenweise ausgeben
        String s;
        while ((s = reader.ReadLine()) != null) {
            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}