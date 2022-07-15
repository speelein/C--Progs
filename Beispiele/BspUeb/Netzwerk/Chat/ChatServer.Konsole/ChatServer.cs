using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

public class ChatServer {
    TcpListener tcpListener = null;
    IPAddress ipAdr = Dns.GetHostEntry("localhost").AddressList[0];
    const int PORT = 13000;
    int nc, nr;
    ArrayList sessionList;

    public ChatServer() {
        sessionList = new ArrayList();
        try {
            tcpListener = new TcpListener(ipAdr, PORT);
			tcpListener.Start();
            Console.WriteLine(DateTime.Now + "  ChatServer gestartet\n");
		} catch (Exception e) {
			Console.WriteLine(e);
            Console.ReadLine();
            Environment.Exit(1);
		}
	}

    public void Run(object obj) {
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
                Session session = new Session(this, tcpClient, nr);
                sessionList.Add(session);
                ThreadPool.QueueUserWorkItem(new WaitCallback(session.Run));
            }
        } catch (Exception e) {
            lock (this) {
                Console.WriteLine(e);
                Console.ReadLine();
                Environment.Exit(1);
            }
        }
    }

   	public void TellAll(String s) {
		foreach (Session session in sessionList)
            session.TellClient(s);
	}

    public void CheckOut(Session session) {
        lock (this) {
            nc--;
            sessionList.Remove(session);
            Console.WriteLine("\n" + DateTime.Now + "  Klient " + session.ID + " ausgeschieden. Noch aktiv: " + nc);
        }
    }

	public void Prot(String s) {
        lock (this) {
            Console.WriteLine("\n" + DateTime.Now + " " + s);
        }
	}

   	public int NConnects {
        get {
            lock (this) {
                return nc;
            }
        }
	}	

    static void Main() {
        ChatServer cs = new ChatServer();
        ThreadPool.QueueUserWorkItem(new WaitCallback(cs.Run));
        String zeile;
        while ((zeile = Console.ReadLine()) != "Quit!");
        cs.TellAll("#EndOfService!");
    }
}
