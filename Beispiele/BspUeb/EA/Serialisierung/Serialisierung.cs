using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class Serialisierung {
	const string NAME = "demo.bin";
	static void Main() {
		Kunde[] kunden = new Kunde[2];
        kunden[0] = new Kunde(1, "Fritz", "Orth", 1, 13, 426.89);
        kunden[1] = new Kunde(2, "Ludwig", "Knüller", 2, 17, 89.10);

        Console.WriteLine("Zu sichern:\n");
        foreach(Kunde k in kunden)
            k.prot();

        FileStream  fs = new FileStream(NAME,FileMode.Create);
		IFormatter bifo = new BinaryFormatter();

        foreach (Kunde k in kunden)
            bifo.Serialize(fs, k);

		fs.Position=0;
        Console.WriteLine("\nRekonstruiert:\n");
        for (int i = 0; i < kunden.Length; i++) {
            Kunde unbekannt = (Kunde)bifo.Deserialize(fs);
            unbekannt.prot();
        }
        Console.ReadLine();
	}
}
