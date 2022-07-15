using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class TcpServerTPL {
	static int noClients;
	static int noActiveClients;
	static int maxUsedWorker;
	static int maxUsedIO;
	static Object lockObject = new object();

	static async Task ServeClientAsync(TcpClient client) {
		using (client) {
			int clientId;
			lock (lockObject) {
				noActiveClients++;
				clientId = ++noClients;
			}
			Console.WriteLine("\nClient " + clientId + ", " + DateTime.Now + ", Anfrage von\n  IP-Nummer:\t" +
								(client.Client.RemoteEndPoint as IPEndPoint).Address + "\n  Port:   \t" +
								(client.Client.RemoteEndPoint as IPEndPoint).Port);
			NetworkStream stream = client.GetStream();
			byte[] msg = Encoding.ASCII.GetBytes(DateTime.Now.ToString());
			await stream.WriteAsync(msg, 0, msg.Length);
			byte[] answer = new byte[1];
			await stream.ReadAsync(answer, 0, 1);
			Console.WriteLine("Client served: " + clientId+ ", Worker Thread Id: " + Thread.CurrentThread.ManagedThreadId);
			lock (lockObject) {
				noActiveClients--;
			}
		}
	}

	static void ThreadUsage() {
		int usedWorker, usedIO;
		ThreadPool.GetMaxThreads(out int maxWorker, out int maxIO);
		ThreadPool.GetAvailableThreads(out int availableWorker, out int availableIO);
		usedWorker = maxWorker - availableWorker;
		if (usedWorker > maxUsedWorker)
			maxUsedWorker = usedWorker;
		usedIO = maxIO - availableIO;
		if (usedIO > maxUsedIO)
			maxUsedIO = usedIO;
		//Console.WriteLine($"Used Worker Threads: {usedWorker}");
		//Console.WriteLine($"Used I/O Threads:    {usedIO}");
	}

	static async Task Main() {
		int svrPort = 55555;
		const int mxClients = 30;
		// IP-Adresse ermitteln, die belauscht werden soll
		IPAddress ip = Dns.GetHostEntry("localhost").AddressList[1];

		TcpListener server = null;
		Task[] clientTasks = new Task[mxClients];
		try {
			server = new TcpListener(ip, svrPort);
			server.Start();
			Console.WriteLine("Zeitserver lauscht seit " + DateTime.Now + " (IP: " +
				ip + ", Port: " + svrPort + ")");
			int clientsAccepted = 0;
			while (++clientsAccepted <= mxClients) {
				Console.WriteLine($"\nReady for client {clientsAccepted}" +
									$" (currently active: {noActiveClients})");
				clientTasks[clientsAccepted-1] = ServeClientAsync(await server.AcceptTcpClientAsync());
				ThreadUsage();
			}
			Task.WaitAll(clientTasks);
			Console.WriteLine($"\nMax. number of worker threads simultaneously used: {maxUsedWorker}");
			Console.WriteLine($"Max. number of IOCP-Threads simultaneously used:   {maxUsedIO}");
		} catch (Exception e) {
			Console.WriteLine(e);
		} finally {
			server.Stop();
		}
	}
}
