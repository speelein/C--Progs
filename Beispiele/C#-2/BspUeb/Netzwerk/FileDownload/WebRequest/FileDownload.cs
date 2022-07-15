using System;
using System.IO;
using System.Net;

class FileDownload {
	static void Main(string[] args) {
		WebResponse response = null;
		FileStream fs = null;
		const int BUFSIZE = 4096;
        DateTime date;
		
		if (args.Length < 3) {
			Console.WriteLine("Aufruf: FileDownload <URI> <Dateiname> <Datum>");
            Console.ReadLine();
            return;
		}

        try {
            date = new DateTime(Convert.ToInt32(args[2].Substring(0, 4)),
                                Convert.ToInt32(args[2].Substring(5, 2)),
                                Convert.ToInt32(args[2].Substring(8, 2)));
        } catch {
            Console.WriteLine("Datumsformat: jjjj.mm.tt");
            Console.ReadLine();
            return;
        }

        WebRequest request = WebRequest.Create(args[0]);
        ((HttpWebRequest)request).IfModifiedSince = date;
        try {
            response = request.GetResponse();
        } catch (WebException) {
            Console.WriteLine("Keine aktuelle Version vorhanden");
            Console.ReadLine();
            return;
        }

        try {
            Stream webStream = response.GetResponseStream();            
            byte[] buffer = new byte[BUFSIZE];
			fs = new FileStream(args[1], FileMode.Create);
			int bytesRead;
			int sumRead = 0;
			Console.WriteLine("Download beginnt ...");
			while((bytesRead = webStream.Read(buffer, 0, buffer.Length)) > 0) {
				fs.Write(buffer, 0, bytesRead);
				sumRead += bytesRead;
			}
			Console.WriteLine("Fertig: "+sumRead+" Bytes übertragen");
            Console.ReadLine();
		} catch(Exception e) {
			Console.WriteLine(e);
		}
	}
}
