using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class EchoHandler {
	TcpClient tcpClient;
	ThreadPoolEchoServer server;
	int clientID;
	NetworkStream stream;

	public EchoHandler(ThreadPoolEchoServer server_, TcpClient tcpClient_, int clientID_) {
		server = server_;
		tcpClient = tcpClient_;
		clientID = clientID_;
		stream = tcpClient.GetStream();
		stream.ReadTimeout = 10000;
	}

	void Close() {
		// Socket in TcpClient auffordern, vor dem Schlieﬂen alle Daten zu empfangen bzw. zu senden
		tcpClient.Client.Shutdown(SocketShutdown.Both);
		// Ressourcen frei geben
		tcpClient.Close();
		server.CheckOut(clientID);
	}

	public void Run(object obj) {
		int n;
		byte[] buffer = new byte[80];
		try {
			while (true) {
				n = stream.Read(buffer, 0, buffer.Length);
				stream.Write(buffer, 0, n);
			}
		} catch {
		} finally {
			Close();
		}
	}
}
