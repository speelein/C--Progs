using System;
using System.Net.Sockets;
using System.Text;

class TcpClientDemo {
	static void Main() {
		String svr = "localhost";
		int port = 13000;
		try {
			TcpClient tcpClient = new TcpClient(svr, port);
			NetworkStream stream = tcpClient.GetStream();
			byte[] bZeit = new byte[48];
			stream.ReadTimeout = 1000;
			int nRead = stream.Read(bZeit, 0, bZeit.Length);
			string sZeit = Encoding.ASCII.GetString(bZeit, 0, nRead);
			Console.WriteLine("Datum und Zeit von {0}: {1}", svr, sZeit);
			// TcpClient samt NetworkStream und Socket schlieﬂen
			tcpClient.Close();
		} catch (Exception e) {
			Console.WriteLine(e);
		}
		Console.ReadLine();
	}
}
