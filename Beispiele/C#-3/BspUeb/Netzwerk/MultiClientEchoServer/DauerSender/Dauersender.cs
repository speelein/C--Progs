using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Dauersender {
	static void Main() {
		const string SVR = "localhost";
        const int PORT = 13000;
		const int lenMessage = 10;
		char[] zbuffer = new char[lenMessage];
		byte[] inBuffer = new byte[lenMessage];
		int ziffer0 = (int) '0';
		Random zzg = new Random();
		TcpClient client = null;
		long n = 0;
		Console.WriteLine("Dauersender/empfänger gestartet\n");
		try {
			client = new TcpClient(SVR, PORT);
			NetworkStream stream = client.GetStream();
			while (true) {
				Console.Write("Sendung " + (++n) + ": ");
				for (int j = 0; j < lenMessage; j++) {
					zbuffer[j] = (char) (ziffer0 + zzg.Next(10));
					Console.Write(zbuffer[j]);
				}
				stream.Write(Encoding.ASCII.GetBytes(zbuffer), 0, lenMessage);
				Thread.Sleep(1000);
				stream.Read(inBuffer, 0, lenMessage);
				Console.WriteLine("   Echo: "+Encoding.ASCII.GetString(inBuffer));
                for (int i = 0; i < inBuffer.Length; i++ )
                    inBuffer[i] = 0;
			}
		} catch (Exception e) {
			Console.WriteLine(e);
            Console.ReadLine();
		}
	}
}
