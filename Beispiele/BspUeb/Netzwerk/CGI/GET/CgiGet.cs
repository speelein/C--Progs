using System;
using System.Net;
using System.Text;
using System.Web;

class CgiGet {
	static void Main() {
        const String CGIURI = "http://www.uni-trier.de/cgi-bin/moose/surveys/beispiel1/cgi.pl";
		
		Console.WriteLine("Geben Sie bitte Ihren Vornamen an");
		Console.Write("Vorname: ");
        String vorName = HttpUtility.UrlEncode(Console.ReadLine(), Encoding.Default);

		Console.WriteLine("Geben Sie bitte Ihren Nachnamen an");
		Console.Write("Nachname: ");
		String nachName = HttpUtility.UrlEncode(Console.ReadLine(), Encoding.Default);
		Console.WriteLine("\nAnforderung wird übertragen ...");

        WebClient client = new WebClient();
		byte[] antwort = client.DownloadData(CGIURI+"?vorname="+vorName+"&nachname="+nachName);

        String s = HttpUtility.UrlDecode(antwort, Encoding.Default);
        Console.WriteLine("\nAntwort :\n{0}", s);
        Console.ReadLine();
	}
}