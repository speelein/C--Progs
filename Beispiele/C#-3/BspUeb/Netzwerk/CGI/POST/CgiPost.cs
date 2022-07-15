using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web;

class CgiPost {
	static void Main() {
		String cgiuri = "http://urtkurs.uni-trier.de/prokur/netz/cgip.php";
		
		Console.WriteLine("Geben Sie bitte Ihren Vornamen an");
		Console.Write("Vorname: ");
		String vorName = HttpUtility.UrlEncode(Console.ReadLine(), Encoding.Default);

		Console.WriteLine("Geben Sie bitte Ihren Nachnamen an");
		Console.Write("Nachname: ");
		String nachName = HttpUtility.UrlEncode(Console.ReadLine(), Encoding.Default);

		// NameValueCollection-Objekt für die Formulardaten erstellen
		NameValueCollection formData = new NameValueCollection();
		formData.Add("vorname", vorName);
		formData.Add("nachname",nachName);

		Console.WriteLine("\nAnforderung wird übertragen ...");
		WebClient client = new WebClient();
		byte[] antwort = null;
		try {
			antwort = client.UploadValues(cgiuri, formData);
			String s = HttpUtility.UrlDecode(antwort, Encoding.Default);
			Console.WriteLine("\nAntwort:\n" + s);
		} catch (Exception e) {
			Console.WriteLine(e.Message);
		}
		Console.ReadLine();
	}
}