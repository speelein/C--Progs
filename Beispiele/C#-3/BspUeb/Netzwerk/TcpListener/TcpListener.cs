using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class TcpListenerDemo {
static void Main() {
	TcpListener server = null;
	int svrPort = 13000;
    IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
	//IPAddress ip = Dns.GetHostEntry("Bernhard").AddressList[1];
    TcpClient tcpClient = null;
    NetworkStream stream = null;

    try {
        server = new TcpListener(ip, svrPort);
        server.Start();
        Console.WriteLine("Zeitserver lauscht seit " + DateTime.Now + " (IP: " +
            ip + ", Port: " + svrPort + ")");
        while (true) {
            // Achtung: Aufruf blockiert!
            tcpClient = server.AcceptTcpClient();
            Console.WriteLine("\n" + DateTime.Now + " Anfrage von\n  IP-Nummer:\t"
                              + (tcpClient.Client.RemoteEndPoint as IPEndPoint).Address + "\n  Port:   \t"
                              + (tcpClient.Client.RemoteEndPoint as IPEndPoint).Port);
            stream = tcpClient.GetStream();
            byte[] msg = Encoding.ASCII.GetBytes(DateTime.Now.ToString());
            stream.Write(msg, 0, msg.Length);
            // Stellt sicher, dass vor dem Schlieﬂen alle Daten gesendet werden:
            tcpClient.Client.Shutdown(SocketShutdown.Send);
            // Verwaltete Ressourcen (z.B. Socket-Objekt)und
            // nicht-verwaltet Ressourcen (TCP-Socket) frei geben:
            tcpClient.Close();
        }
    } catch (Exception e) {
        Console.WriteLine(e);
        Console.ReadLine();
    }
}
}
