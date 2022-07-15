using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class ThreadPoolEchoServer {
    TcpListener tcpListener = null;
    IPAddress ipAdr = Dns.GetHostEntry("localhost").AddressList[0];
    const int PORT = 13000;
    int nc, nr;

    public ThreadPoolEchoServer() {
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
                ThreadPool.QueueUserWorkItem(new WaitCallback(echoHandler.Run));
// so gehts auch:                ThreadPool.QueueUserWorkItem(echoHandler.Run);
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
        ThreadPoolEchoServer mces = new ThreadPoolEchoServer();
        mces.Run();
    }
}
