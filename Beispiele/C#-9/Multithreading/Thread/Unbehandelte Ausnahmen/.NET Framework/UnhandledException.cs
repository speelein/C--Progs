using System;
using System.Threading;

class UnhandledException {
	static void Werfer() {
		Thread.Sleep(3000);
		throw new InvalidOperationException("Aus einem sekundären Thread");
	}

	static void UnHandler(object sender, UnhandledExceptionEventArgs e) {
		Console.WriteLine("\nUnbehandelte Ausnahme: " +
		                  $"{((Exception) e.ExceptionObject).Message}\n");
		// Protokoll in eine Logdatei schreiben
	}

	public static void Main() {
		AppDomain.CurrentDomain.UnhandledException += UnHandler;
		new Thread(Werfer).Start();
		for(int i = 0; i <= 10; i++) {
			Thread.Sleep(1000);
			Console.WriteLine("Ausgabe durch den Main-Thread: "+ i);
		}
	}
}
