using System;
using System.IO;

class OrdnerVerwaltung {
	static void Main() {
        const string DIR1 = @"U:\Eigene Dateien\C#\EA\";
        const string DIR2 = @"U:\Eigene Dateien\C#\EA\Sub\";

        Directory.SetCurrentDirectory(DIR1);
        Directory.CreateDirectory(DIR2);

        // �ber Dateien informieren (mit Filter)
        DirectoryInfo di = new DirectoryInfo(".");
        FileInfo[] fia = di.GetFiles("*.txt");
        Console.WriteLine("Textdateien in {0}\n", Directory.GetCurrentDirectory());
        Console.WriteLine("{0, 20} {1, 20}", "Name", "Letzte �nderung");
        foreach (FileInfo fi in fia)
            Console.WriteLine("{0, 20} {1, 20}", fi.Name, fi.LastWriteTime);

        // �ber Unterordner informieren
        DirectoryInfo[] dia = di.GetDirectories();
        Console.WriteLine("\n\nOrdner in {0}\n", di.FullName);
        Console.WriteLine("{0, 20} {1, 20}", "Name", "Letzte �nderung");
        foreach (DirectoryInfo die in dia)
            Console.WriteLine("{0, 20} {1, 20}", die.Name, die.LastWriteTime);

        // Ordner l�schen
        Directory.Delete(DIR2, true);
        Console.ReadLine();
    }
}
