using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class MultiThreadEchoServer {
    TcpListener tcpListener = null;
    IPAddress ipAdr = Dns.GetHostEntry("localhost").AddressList[0];
    const int PORT = 13000;
    int nc, nr;

    public MultiThreadEchoServer() {
		try {
            tcpListener = new TcpListener(ipAdr, PORT);
			tcpListener.Start();
            Console.WriteLine(DateTime.Now + "  MultiClientEchoServer gestartet\n");
		} catch (Exception e) {
			Console.WriteLine(e);
            Console.ReadLine();
		}
	}

    public void Run() {
        try {
            while (true) {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                lock (this) {
                    nc++;
                    nr++;
                    Console.WriteLine("\n" + DateTime.Now + "  Klient " + nr + " akzeptiert. Aktiv: " + nc + "\n  IP-Nummer:\t" +
                            (tcpClient.Client.RemoteEndPoint as IPEndPoint).Address + "\n  Port:   \t" +
                            (tcpClient.Client.RemoteEndPoint as IPEndPoint).Port);
                }
                EchoHandler echoHandler = new EchoHandler(this, tcpClient, nr);
                Thread echoThread = new Thread(new ThreadStart(echoHandler.Run));
// so gehts auch:                 Thread echoThread = new Thread(echoHandler.Run);
                echoThread.IsBackground = true;
                echoThread.Start();
            }
        } catch (Exception e) {
            lock (this) {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }
    }

    public void CheckOut(int clientID) {
        lock (this) {
            nc--;
            Console.WriteLine("\n" + DateTime.Now + "  Klient " + clientID + " ausgeschieden. Noch aktiv: " + nc);
        }
    }

    static void Main() {
        MultiThreadEchoServer mces = new MultiThreadEchoServer();
        mces.Run();
    }
}
