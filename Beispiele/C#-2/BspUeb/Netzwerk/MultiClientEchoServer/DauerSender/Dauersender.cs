using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Dauersender {
	static void Main() {
		const string SVR = "localhost";
        const int PORT = 13000;
		char[] zbuffer = new char[10];
		byte[] outBuffer = new byte[10];
        byte[] inBuffer = new byte[10];
		int ziffer0 = (int) '0';
		Random zzg = new Random();
		TcpClient client = null;
		long n = 0;
		Console.WriteLine("Dauersender/empfänger gestartet");
		try {
			client = new TcpClient(SVR, PORT);
			NetworkStream stream = client.GetStream();
			while (true) {
				for (int j = 0; j < 10; j++)
					zbuffer[j] = (char) (ziffer0 + zzg.Next(10));
				stream.Write(Encoding.ASCII.GetBytes(zbuffer), 0, outBuffer.Length);
				Thread.Sleep(1000);
				stream.Read(inBuffer, 0, 10);
				Console.WriteLine("Sendung "+(++n)+": "+Encoding.ASCII.GetString(inBuffer));
                for (int i = 0; i < inBuffer.Length; i++ )
                    inBuffer[i] = 0;
			}
		} catch (Exception e) {
			Console.WriteLine(e);
            Console.ReadLine();
		} finally {
			if (client != null)
                client.Close();
		}
	}
}
