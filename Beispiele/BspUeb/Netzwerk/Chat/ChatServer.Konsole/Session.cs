using System;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;

public class Session {
    TcpClient tcpClient;
    ChatServer server;
    int clientID;
    String clientName;
    StreamReader reader;
    StreamWriter writer;

    public Session(ChatServer cs, TcpClient tc, int nr) {
		server = cs;
        tcpClient = tc;
        clientID = nr;
        NetworkStream stream = tcpClient.GetStream();
        // ReadTimeout: 5 Minuten
        stream.ReadTimeout = 300000;
        // StreamReader erstellen, um aus dem NetworkStream zu lesen
        reader = new StreamReader(stream);
        // StreamWriter erstellen, um in den NetworkStream zu schreiben
        writer = new StreamWriter(stream);
        writer.AutoFlush = true;
	}

	public void Run(object obj) {
        try {
            String zeile = reader.ReadLine();
            if (zeile.Length >= 10 && zeile.Substring(0, 10) == "#UserName=") {
                // Vom Teilnehmer gewünschter Benutzername mit maximal 12 Zeichen
                clientName = zeile.Substring(11, zeile.IndexOf("!") - 12);
            } else {
                // Ersatzweise wird der Host-Name verwendet.
                clientName = Dns.GetHostEntry((tcpClient.Client.RemoteEndPoint as IPEndPoint).Address).HostName;
                int pos = clientName.IndexOf(".");
                if (pos > 0)
                    clientName = clientName.Substring(0, pos);
            }
            // Namen ggf. auf 12 Zeichen kürzen
            clientName = clientName.Substring(0, Math.Min(clientName.Length, 12));
            writer.WriteLine("Willkommen, " + clientName + "! - Aktive Teilnehmer: " + server.NConnects);
            writer.WriteLine("");

            // Namen mit Leerzeichen auf der rechten Seite auf Gesamtlänge 12 bringen            
            clientName = clientName.PadRight(12);
            
            while ((zeile = reader.ReadLine()) != null) {
                if (zeile == "#Quit!") {
                    writer.WriteLine("#Bye!");
                    break;
                } else if (zeile.Length >= 10 && zeile.Substring(0, 10) == "#UserName=") {
                    // Vom Teilnehmer gewünschter Benutzername mit maximal 12 Zeichen
                    clientName = zeile.Substring(11, Math.Min(zeile.IndexOf("!") - 12, 12));
                    writer.WriteLine("Ihr neuer Name " + clientName);
                    writer.WriteLine("");
                } else
                    server.TellAll(clientName + ": " + zeile);
			}
		} catch (Exception e) {
			server.Prot("Fehler bei Verbindung mit clientID "+clientID+" ("+clientName+")\n"+e.Message);
		} finally {
            Close();
		}
	}

    public int ID {
        get {
            return clientID;
        }
    }	

	public void TellClient(String s) {
		writer.WriteLine(s);
	}

    void Close() {
        // Socket in TcpClient auffordern, vor dem Schließen alle Daten zu empfangen bzw. zu senden
        tcpClient.Client.Shutdown(SocketShutdown.Both);
        // TCP-Socket frei geben
        tcpClient.Close();
        // Klient beim Server abmelden
        server.CheckOut(this);
    }
}