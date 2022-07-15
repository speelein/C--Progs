using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class TcpClientDemo {
	static void Main() {
		string svr = "localhost";
		int port = 55555;
		try {
			using (TcpClient tcpClient = new(svr, port)) {
				NetworkStream stream = tcpClient.GetStream();
				byte[] bZeit = new byte[48];
				stream.ReadTimeout = 1000;
				int nRead = stream.Read(bZeit, 0, bZeit.Length);
				string sZeit = Encoding.ASCII.GetString(bZeit, 0, nRead);
				Console.WriteLine("Datum und Zeit von {0}: {1}", svr, sZeit);
			}
		} catch (Exception e) {
			Console.WriteLine(e);
		}
	}
}
