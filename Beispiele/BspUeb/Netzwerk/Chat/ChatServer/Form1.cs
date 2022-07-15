using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;

namespace ChatServerNameSpace {

    delegate void ProtUpdateDelegate(string s);    
    
    public partial class ChatServer : Form {
        TcpListener tcpListener = null;
        String hostName;
        IPAddress ipAdr;
        const int PORT = 13000;
        int nc, nr;
        ArrayList sessionList;
        ProtUpdateDelegate protokollant;

        public ChatServer() {
            InitializeComponent();
            sessionList = new ArrayList();
            protokollant = new ProtUpdateDelegate(ProtUpdate);
            try {
                hostName = Dns.GetHostName();
//                hostName = "localhost";
                ipAdr = Dns.GetHostEntry(hostName).AddressList[0];
                tcpListener = new TcpListener(ipAdr, PORT);
                tcpListener.Start();
                tbProtocol.AppendText(DateTime.Now + "  ChatServer gestartet" + Environment.NewLine);
                this.Text = "ChatServer (v0.2) gestartet auf "+hostName;
            } catch (Exception e) {
                MessageBox.Show(e.Message, "Fehler im Konstruktor");
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
                        String zeile = Environment.NewLine + DateTime.Now + "  Klient " + nr + " akzeptiert. Aktiv: " + nc + Environment.NewLine + "  IP-Nummer: " +
                                (tcpClient.Client.RemoteEndPoint as IPEndPoint).Address.ToString() + Environment.NewLine + "  Port:      " +
                                (tcpClient.Client.RemoteEndPoint as IPEndPoint).Port.ToString();
                        BeginInvoke(protokollant, zeile);
                    }
                    Session session = new Session(this, tcpClient, nr);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(session.Run));
                    sessionList.Add(session);
                }
            } catch (Exception e) {
                lock (this) {
                    MessageBox.Show(e.Message, "Fehler im Server-Thread");
                    Environment.Exit(1);
                }
            }
        }

        void ProtUpdate(string s) {
            tbProtocol.AppendText(Environment.NewLine + s);
        }

        public void TellAll(String s) {
            foreach (Session session in sessionList)
                session.TellClient(s);
        }

        public void TellOthers(String s, Session sender) {
            foreach (Session session in sessionList)
                if (session != sender)
                    session.TellClient(s);
        }

        public void CheckOut(Session session) {
            lock (this) {
                // Session verwerfen
                nc--;
                sessionList.Remove(session);

                // Protokolleintrag; die entfernte Session hatte eventuell noch keinen Namen
                String clientName;
                if (session.Name != null)
                    clientName = session.Name.Trim();
                else
                    clientName = "Unbekannt";
                BeginInvoke(protokollant, Environment.NewLine + DateTime.Now + "  Klient " + session.ID.ToString() +
                    " (" + clientName + ") ausgeschieden. Noch Aktiv: " + nc.ToString());

                // Alle anderen über den Ausstieg informieren
                TellOthers(Environment.NewLine + "CHATSERVER  : Ausgestiegen ist: " + session.Name + Environment.NewLine, session);
            }
        }

        public void Prot(String s) {
            BeginInvoke(protokollant, Environment.NewLine + DateTime.Now + " " + s);
        }

        public int NConnects {
            get {
                lock (this) {
                    return nc;
                }
            }
        }

        public bool ClientNameInUse(Session client, String s) {
            foreach (Session session in sessionList)
                if (session != client)
                    if (session.Name.ToUpper().Trim() == s.ToUpper().Trim()) {
                        return true;
                }
            return false;
        }

        private void cbStop_Click(object sender, EventArgs e) {
            TellAll("#EndOfService!");
            Environment.Exit(0);
        }

        private void ChatServer_FormClosing(object sender, FormClosingEventArgs e) {
            TellAll("#EndOfService!");
        }
    }
}