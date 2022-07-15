using System;
using System.Net.Sockets;
using System.Text;

class TcpClientDemo {
	static void Main() {
        const string SVR = "localhost";
        const int PORT = 13000;
		try {
			TcpClient tcpClient = new TcpClient(SVR, PORT);
            NetworkStream stream = tcpClient.GetStream();
            byte[] bZeit = new byte[48];
            stream.ReadTimeout = 1000;
            int nRead = stream.Read(bZeit, 0, bZeit.Length);
			string sZeit = Encoding.ASCII.GetString(bZeit, 0, nRead);
			Console.WriteLine("Datum und Zeit von {0}: {1}", SVR, sZeit);
            Console.ReadLine();
			// TcpClient samt NetworkStream und Socket schlieﬂen
			tcpClient.Close();
		} catch (Exception e) {
			Console.WriteLine(e);
            Console.ReadLine();
		}
	}
}
