using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ChatClientNameSpace {

    delegate void ProtUpdateDelegate(string s);
    
    public partial class ChatClient : Form {
        const int PORT = 13000;
        TcpClient tcpClient;
        StreamReader reader;
        StreamWriter writer;
        bool connected;
        ProtUpdateDelegate protokollant;

        public ChatClient() {
            InitializeComponent();
            tbMessage.Enabled = false;
            cbSend.Enabled = false;
            tbUserName.Text = Environment.UserName;
            protokollant = new ProtUpdateDelegate(ProtUpdate);
        }

        void Receive(Object obj) {
            String zeile;
            try {
                while (connected && (zeile = reader.ReadLine()) != null) {
                    BeginInvoke(protokollant, zeile);
                    if (zeile == "#Bye!" || zeile == "#EndOfService!")
                        return;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Fehler beim Nachrichtenempfang.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ProtUpdate(string s) {
            if (s == "#Bye!") 
                cbDisconnect_Click(this, EventArgs.Empty);
            else if (s == "#EndOfService!") {
                tbProtocol.AppendText(Environment.NewLine + Environment.NewLine + "CHATCLIENT  : " + tbServer.Text +
                    " hat die Verbindung beendet" + Environment.NewLine);
                Disconnect();
            } else
                tbProtocol.AppendText(Environment.NewLine + s);
        }
        
        private void cbConnect_Click(object sender, EventArgs e) {
            if (connected || tbServer.Text.Length == 0)
                return;
            try {
                tcpClient = new TcpClient(tbServer.Text, PORT);
                reader = new StreamReader(tcpClient.GetStream());
                writer = new StreamWriter(tcpClient.GetStream());
                writer.AutoFlush = true;
                connected = true;
                tbServer.Enabled = false;
                cbConnect.Enabled = false;
                tbUserName.Enabled = false;
                tbMessage.Enabled = true;
                cbSend.Enabled = true;
                this.Text = "ChatClient (" + Application.ProductVersion + ") verbunden mit " + tbServer.Text;
                // Empfänger-Thread starten
                ThreadPool.QueueUserWorkItem(this.Receive);
                // Beim Serer mit einem geeigneten Namen anmelden
                if (tbUserName.Text.Length > 0)
                    writer.WriteLine("#UserName='" + tbUserName.Text.Substring(0, Math.Min(tbUserName.Text.Length, 12)) + "'!");
                else {
                    tbUserName.Text = Environment.UserName;
					writer.WriteLine("#UserName='" + Environment.UserName.Substring(0, Math.Min(Environment.UserName.Length, 12)) + "'!");
                }
                this.AcceptButton = this.cbSend;
                tbMessage.Select();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Fehler bei der Verbindungsaufnahme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbDisconnect_Click(object sender, EventArgs e) {
            if (!connected)
                return;
            try {
                writer.WriteLine("#Quit!");
                tbProtocol.AppendText(Environment.NewLine + Environment.NewLine + "CHATCLIENT  : Verbindung zu " + tbServer.Text + " beendet" + Environment.NewLine);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Fehler beim Quit-Kommando", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                Disconnect();
            }
        }

        private void Disconnect() {
            if (!connected)
                return;
            try {
                connected = false;
                // Der Receive-Thread erhält etwas Zeit, sich zu beenden
                Thread.Sleep(500);
                tcpClient.Client.Shutdown(SocketShutdown.Both);
                tcpClient.Close();
                tbServer.Enabled = true;
                cbConnect.Enabled = true;
                tbUserName.Enabled = true;
                tbMessage.Text = "";
                tbMessage.Enabled = false;
                cbSend.Enabled = false;
				this.Text = "ChatClient (" + Application.ProductVersion + ")";
                this.AcceptButton = this.cbConnect;
                tbServer.Select();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Fehler beim Schließen der Verbindung", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cdSend_Click(object sender, EventArgs e) {
            if (tbMessage.Text.Length > 0)
                try {
                    writer.WriteLine(tbMessage.Text);
                    // gesendeten Text markieren
                    tbMessage.SelectionStart = 0;
                    tbMessage.SelectionLength = tbMessage.Text.Length;
					tbMessage.Select();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Fehler beim Senden der Nachricht", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void cbEnd_Click(object sender, EventArgs e) {
            if (connected)
                cbDisconnect_Click(new object(), EventArgs.Empty);
            Environment.Exit(0);
        }

        private void Form1_Activated(object sender, EventArgs e) {
            // Beim Erscheinen des Formulars soll die Textbox mit dem Servernamen den Fokus haben.
			tbServer.Select();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (connected)
                cbDisconnect_Click(new object(), EventArgs.Empty);
        }
    }
}