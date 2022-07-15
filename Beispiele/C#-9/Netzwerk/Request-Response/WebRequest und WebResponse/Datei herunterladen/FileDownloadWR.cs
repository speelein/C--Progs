using System;
using System.IO;
using System.Net;

class FileDownloadWR {
	static void Main(string[] args) {
		if (args.Length < 3) {
			Console.WriteLine("Aufruf: filedownload <URI> <Dateiname> <jjjj.mm.tt>");
			Console.ReadLine();
			return;
		}

		try {
			DateTime date = new(Convert.ToInt32(args[2].Substring(0, 4)),
								Convert.ToInt32(args[2].Substring(5, 2)),
								Convert.ToInt32(args[2].Substring(8, 2)));
			WebRequest request = WebRequest.Create(args[0]);
			((HttpWebRequest)request).IfModifiedSince = date;
			using (WebResponse response = request.GetResponse())
				using (Stream ws = response.GetResponseStream())
					using (FileStream fs = new(args[1], FileMode.Create)) {
						Console.WriteLine("Download beginnt ...");
						ws.CopyTo(fs);
						Console.WriteLine("Fertig: " + fs.Length + " Bytes übertragen");
					}
		} catch (FormatException) {
			Console.WriteLine("Korrektes Datumsformat: jjjj.mm.tt");
		} catch (Exception e) {
			Console.WriteLine(e.Message);
		}
	}
}
