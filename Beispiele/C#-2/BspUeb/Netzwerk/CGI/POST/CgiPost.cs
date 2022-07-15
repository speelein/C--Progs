using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web;

class CgiPost {
	static void Main() {
        const string CGIURI = "http://www.uni-trier.de/cgi-bin/moose/surveys/beispiel1/cgi.pl";
		
		// NameValueCollection-Objekt für die Formulardaten erstellen
		NameValueCollection formData = new NameValueCollection();

		Console.WriteLine("Geben Sie bitte Ihren Vornamen an");
		Console.Write("Vorname: ");
        String vorName = HttpUtility.UrlEncode(Console.ReadLine(), Encoding.Default);

		Console.WriteLine("Geben Sie bitte Ihren Nachnamen an");
		Console.Write("Nachname: ");
        String nachName = HttpUtility.UrlEncode(Console.ReadLine(), Encoding.Default);

		formData.Add("vorname",vorName);
		formData.Add("nachname",nachName);

		Console.WriteLine("\nAnforderung wird übertragen ...");
		WebClient client = new WebClient();

		byte[] antwort = client.UploadValues(CGIURI, formData);

        String s = HttpUtility.UrlDecode(antwort, Encoding.Default);
        Console.WriteLine("\nAntwort :\n{0}", s);
        Console.ReadLine();
	}
}