using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class TcpServer {
	static void Main() {
		int svrPort = 55555;
		// IP-Adresse ermitteln, die belauscht werden soll
		IPAddress ip = Dns.GetHostEntry("localhost").AddressList[1];

		TcpListener server = null;
		NetworkStream stream = null;
		try {
			server = new TcpListener(ip, svrPort);
			server.Start();
			Console.WriteLine("Zeitserver lauscht seit " + DateTime.Now + " (IP: " +
				ip + ", Port: " + svrPort + ")");
			while (true) {
				// Accept() - Aufruf blockiert
				using (TcpClient tcpClient = server.AcceptTcpClient()) {
					Console.WriteLine("\n" + DateTime.Now + " Anfrage von\n  IP-Nummer:\t" +
						             (tcpClient.Client.RemoteEndPoint as IPEndPoint).Address + "\n  Port:   \t" +
						             (tcpClient.Client.RemoteEndPoint as IPEndPoint).Port);
					stream = tcpClient.GetStream();
					byte[] msg = Encoding.ASCII.GetBytes(DateTime.Now.ToString());
					stream.Write(msg, 0, msg.Length);
				}
			}
		} catch (Exception e) {
			Console.WriteLine(e);
			Console.ReadLine();
		} finally {
			server.Stop();
        }
	}
}
