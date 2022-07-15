using System;
using System.Threading;

class Prog {
	static void HintergrundAktion(object anzahl) {
		Random zzg = new Random();
		int anz = (int)anzahl;
        double summe;
		for (int i = 0; i < anz; i++) {
			summe = 0.0;
			for (int j = 0; j < 10_000_000; j++)
				summe += zzg.Next(100);
			Console.WriteLine("Aktuelle Zufallssumme: " + summe);
		}
		Console.WriteLine("\nDer Arbeits-Thread ist fertig.");
	}

	static void Main() {
		bool b = ThreadPool.QueueUserWorkItem(HintergrundAktion, 5);
		Console.WriteLine("Arbeitsauftrag erfolgreich in die "+
			"Threadpool-Warteschlange gestellt: {0}\n",b);
		Console.WriteLine("Der primäre Thread schläft 5 Sekunden lang.\n");
		Thread.Sleep(5000);
		Console.WriteLine("\nDer primäre Thread ist aufgewacht.\n");
		Console.ReadLine();
	}
}