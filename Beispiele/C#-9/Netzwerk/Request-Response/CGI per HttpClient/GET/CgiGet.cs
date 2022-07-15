using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

class CgiGet {
	static HttpClient client = new();
	static async Task Main() {
		string cgiuri = "https://urtkurs.uni-trier.de/prokur/netz/cgig.php";

		Console.WriteLine("Geben Sie bitte Ihren Vornamen an");
		Console.Write("Vorname: ");
		string vorName = HttpUtility.UrlEncode(Console.ReadLine(), Encoding.Default);

		Console.WriteLine("Geben Sie bitte Ihren Nachnamen an");
		Console.Write("Nachname: ");
		string nachName = HttpUtility.UrlEncode(Console.ReadLine(), Encoding.Default);
		Console.WriteLine("\nDie Anforderung wird übertragen ...");

		try {
			var response = await client.GetAsync(cgiuri + "?vorname=" + vorName + "&nachname=" + nachName);
			Console.WriteLine(response);
			if (response.IsSuccessStatusCode)
				Console.WriteLine("\nAntwort:\n" + await response.Content.ReadAsStringAsync());
		} catch (Exception e) {
			Console.WriteLine(e.Message);
		}
	}
}