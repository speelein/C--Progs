using System;
using System.Net;
using System.Text;
using System.Web;

class CgiGet {
	static void Main() {
		String cgiuri = "http://urtkurs.uni-trier.de/prokur/netz/cgig.php";

		Console.WriteLine("Geben Sie bitte Ihren Vornamen an");
		Console.Write("Vorname: ");
		String vorName = HttpUtility.UrlEncode(Console.ReadLine(), Encoding.Default);

		Console.WriteLine("Geben Sie bitte Ihren Nachnamen an");
		Console.Write("Nachname: ");
		String nachName = HttpUtility.UrlEncode(Console.ReadLine(), Encoding.Default);
		Console.WriteLine("\nAnforderung wird übertragen ...");

		WebClient client = new WebClient();
		byte[] antwort = null;
		try {
			antwort = client.DownloadData(cgiuri + "?vorname=" + vorName +
				"&nachname=" + nachName);
			String s = HttpUtility.UrlDecode(antwort, Encoding.Default);
			Console.WriteLine("\nAntwort:\n" + s);
		} catch (Exception e) {
			Console.WriteLine(e.Message);
		}
		Console.ReadLine();
	}
}