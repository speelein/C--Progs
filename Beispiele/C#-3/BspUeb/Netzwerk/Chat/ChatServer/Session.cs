using System;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace ChatServerNameSpace {
    public class Session {
        TcpClient tcpClient;
        ChatServer server;
        int clientID;
        String clientName;
        NetworkStream stream;
        StreamReader reader;
        StreamWriter writer;

        public Session(ChatServer cs, TcpClient tc, int nr) {
            server = cs;
            tcpClient = tc;
            clientID = nr;
        }

        bool InitConnection() {
            try {
                stream = tcpClient.GetStream();
                // ReadTimeout: 5 Sekunden
                stream.ReadTimeout = 5000;
                // StreamReader erstellen, um aus dem NetworkStream zu lesen
                reader = new StreamReader(stream);
                // StreamWriter erstellen, um in den NetworkStream zu schreiben
                writer = new StreamWriter(stream);
                writer.AutoFlush = true;

                String zeile = reader.ReadLine();
                String wunschName = "";
                if (zeile.Length >= 10 && zeile.Substring(0, 10) == "#UserName=") {
                    // Vom Teilnehmer gewünschter Benutzername mit maximal 12 Zeichen
                    wunschName = zeile.Substring(11, zeile.IndexOf("!") - 12).Trim();
                    wunschName = wunschName.Substring(0, Math.Min(wunschName.Length, 12));
                }
                if (NameAcceptable(wunschName))
                    clientName = wunschName;
                else {
                    // Ersatzweise wird der Host-Name verwendet.
                    clientName = Dns.GetHostEntry((tcpClient.Client.RemoteEndPoint as IPEndPoint).Address).HostName;
                    int pos = clientName.IndexOf(".");
                    if (pos > 0)
                        clientName = clientName.Substring(0, pos);
                    clientName = clientName.Substring(0, Math.Min(clientName.Length, 12));
                }
                writer.WriteLine("CHATSERVER  : Willkommen, " + clientName + "! - Aktive Teilnehmer: " + server.NConnects + Environment.NewLine);

                // Alle anderen über den neuen Teilnehmer informieren
                server.TellOthers(Environment.NewLine + "CHATSERVER  : Neuer Teilnehmer: " + clientName + Environment.NewLine, this);

                // Namen mit Leerzeichen auf der rechten Seite auf Gesamtlänge 12 bringen zur Formatierung der Client-Ausgabe            
                clientName = clientName.PadRight(12);
            } catch (Exception e) {
                server.Prot("Fehler bei Verbindungsaufnahme mit clientID " + clientID + Environment.NewLine + e.Message);
                return false;
            }
            return true;
        }

        bool NameAcceptable(String name) {
            if (name.Length == 0)
                return false;
            if (name.Length >= 10 && name.Substring(0, 10).ToUpper() == "CHATSERVER")
                return false;
            if (server.ClientNameInUse(this, name))
                return false;
            return true;
        }

        public void Run(object obj) {
            String zeile, wunschName, alterName;
			String message = "";
            try {
                if (InitConnection()) {
                    // ReadTimeout: 30 Minuten
                    stream.ReadTimeout = 1800000;
                    while ((zeile = reader.ReadLine()) != null)
                        if (zeile == "#Quit!") {
                            writer.WriteLine("#Bye!");
                            break;
                        } else if (zeile.Length >= 10 && zeile.Substring(0, 10) == "#UserName=") {
                            // Vom Teilnehmer gewünschter Benutzername mit maximal 12 Zeichen
                            wunschName = zeile.Substring(11, zeile.IndexOf("!") - 12).Trim();
                            wunschName = wunschName.Substring(0, Math.Min(wunschName.Length, 12));
                            if (NameAcceptable(wunschName)) {
								alterName = clientName;
								clientName = wunschName;
                                writer.WriteLine(Environment.NewLine + "CHATSERVER  : Ihr neuer Name: " + clientName + Environment.NewLine);
								server.TellOthers(Environment.NewLine + "CHATSERVER  : " + alterName + " heißt jetzt :" + clientName + Environment.NewLine, this);
                            }
                        } else
                            server.TellAll(clientName + ": " + zeile);
                }
            } catch (IOException ioe) {
                server.Prot("ReadTimeout bei Verbindung mit clientID " + clientID + " (" + clientName + ")\n" + ioe.Message);
				message = ioe.Message;
            } catch (Exception e) {
                server.Prot("Fehler bei Verbindung mit clientID " + clientID + " (" + clientName + ")\n" + e.Message);
				message = e.Message;
            } finally {
				writer.WriteLine(Environment.NewLine + "CHATSERVER  : " + message + Environment.NewLine);
				writer.WriteLine("#EndOfService!");
				CloseSession();
            }
        }

        public int ID {
            get {
                return clientID;
            }
        }

        public String Name {
            get {
                return clientName;
            }
        }

        public void TellClient(String s) {
            writer.WriteLine(s);
        }

        void CloseSession() {
            // Socket in TcpClient auffordern, vor dem Schließen alle Daten zu empfangen bzw. zu senden
            tcpClient.Client.Shutdown(SocketShutdown.Both);
            // TCP-Socket frei geben
            tcpClient.Close();
            // Klient beim Server abmelden
            server.CheckOut(this);
        }
    }
}