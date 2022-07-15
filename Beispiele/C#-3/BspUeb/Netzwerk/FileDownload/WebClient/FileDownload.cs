using System;
using System.Net;

class FileDownload {
	static void Main(string[] args) {
		if (args.Length < 2) {
			Console.WriteLine("Aufruf: FileDownload <URI> <Dateiname>");
			Console.ReadLine();
			return;
		}

		try	{
			WebClient client = new WebClient();
			Console.WriteLine("Download startet");
			client.DownloadFile(args[0], args[1]);
			Console.WriteLine("Fertig!");
			Console.ReadLine();
		} catch(Exception e) {
			Console.WriteLine(e);
			Console.ReadLine();
		}
	}
}
