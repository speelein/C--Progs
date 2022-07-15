using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

class CgiPost {
	static HttpClient client = new();
	static async Task Main() {
		string cgiuri = "https://urtkurs.uni-trier.de/prokur/netz/cgip.php";
		
		Console.WriteLine("Geben Sie bitte Ihren Vornamen an");
		Console.Write("Vorname: ");
		string vorName = Console.ReadLine();

		Console.WriteLine("Geben Sie bitte Ihren Nachnamen an");
		Console.Write("Nachname: ");
		string nachName = Console.ReadLine();

		var formData = new Dictionary<string, string> {
			{ "vorname", vorName },	{ "nachname", nachName }
		};
		var formDataEnc = new FormUrlEncodedContent(formData);

		Console.WriteLine("\nDie Anforderung wird übertragen ...");
		try {
			var response = await client.PostAsync(cgiuri, formDataEnc);
			//Console.WriteLine(response);
			if (response.IsSuccessStatusCode)
				Console.WriteLine(await response.Content.ReadAsStringAsync());
		} catch (Exception e) {
			Console.WriteLine(e.Message);
		}
	}
}