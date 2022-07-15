using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class Serialisierung {
	static string name = "demo.bin";
	static void Main() {
		Kunde[] kunden = new Kunde[2];
		kunden[0] = new Kunde(1, "Fritz", "Orth", 1, 13, 426.89);
		kunden[1] = new Kunde(2, "Ludwig", "Knüller", 2, 17, 89.10);

		Console.WriteLine("Zu sichern:\n");
		foreach (Kunde k in kunden)
			k.Prot();

		FileStream fs = new FileStream(name, FileMode.Create);
		IFormatter bifo = new BinaryFormatter();

		bifo.Serialize(fs, kunden);

		fs.Position = 0;
		Console.WriteLine("\nRekonstruiert:\n");
		Kunde[] desKunden = (Kunde[]) bifo.Deserialize(fs);
		foreach(Kunde k in desKunden)
			k.Prot();
		Console.ReadLine();
	}
}