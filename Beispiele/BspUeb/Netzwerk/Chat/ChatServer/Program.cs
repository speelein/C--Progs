using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace ChatServerNameSpace {
    static class Program {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ChatServer cs = new ChatServer();
            // Server-Thread starten (nimmt Anmedlungen entgegen, startet Session-Threads)
            ThreadPool.QueueUserWorkItem(new WaitCallback(cs.Run));
            Application.Run(cs);
        }
    }
}