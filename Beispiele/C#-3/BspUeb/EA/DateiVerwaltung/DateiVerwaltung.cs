using System;
using System.IO;

class DateiVerwaltung {
	static void Main() {
        const string PFAD1 = @"U:\Eigene Dateien\C#\EA\demo.txt";
        const string PFAD2 = @"U:\Eigene Dateien\C#\EA\kopie.txt";
        const string PFAD3 = @"U:\Eigene Dateien\C#\EA\nn.txt";

        // File.Create(PFAD1) entspricht new FileStream(PFAD1, FileMode.Create).
        FileStream fs = File.Create(PFAD1);
        fs.Close();
        // File.CreateText(PFAD1) entspricht new StreamWriter(PFAD1).
        StreamWriter sw = File.CreateText(PFAD1);
        sw.WriteLine("File-Demo");
        // Ohne Close() klappt sp�ter das Umbenennen nicht.
        sw.Close();
        // Kopieren (�berschreiben ist erlaubt)
        File.Copy(PFAD1, PFAD2, true);
        // L�schen, falls existent
        if (File.Exists(PFAD3))
            File.Delete(PFAD3);
        // Umbenennen
        File.Move(PFAD1, PFAD3);
        // Kreations- und �nderungsdatum setzen
        File.SetCreationTime(PFAD3, new DateTime(2005, 12, 29, 22, 55, 44));
        File.SetLastWriteTime(PFAD3, new DateTime(2005, 12, 29, 22, 55, 44));
        // FileInfo-Eigenschaften auslesen
        FileInfo fi = new FileInfo(PFAD3);
        Console.WriteLine("Die Datei           {0} wurde\n  erstellt:         {1}"+
            "\n  zuletzt ge�ndert: {2}", fi.Name, fi.CreationTime, fi.LastWriteTime);
		// L�schen per FileInfo-Instanzmethode
		fi.Delete();
        Console.ReadLine();
    }
}
