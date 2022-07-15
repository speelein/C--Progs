using System;
using System.IO;

public class TxtWatcher {
	static void Main(String[] args) {
        FileSystemWatcher watcher = new FileSystemWatcher(args[0]);

		// Zu �berwachen: �ndern und Umbenennen von Dateien
		watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
		// Filter f�r Dateinamen
		watcher.Filter = "*.txt";
		
		// Ereignisbehandlungsroutinen registrieren
		watcher.Changed += new FileSystemEventHandler(FsoChanged);
		watcher.Created += new FileSystemEventHandler(FsoChanged);
		watcher.Deleted += new FileSystemEventHandler(FsoChanged);
		watcher.Renamed += new RenamedEventHandler(FsoRenamed);
		
		// �berwachung aktivieren
		watcher.EnableRaisingEvents = true;
		
		Console.WriteLine("TxtWatcher gestartet. Beenden mit 'q' + Enter\n");
		Console.WriteLine("�berwachter Ordner: "+args[0]+"\n");
		ConsoleKeyInfo cki;
        do
            cki = Console.ReadKey(true);
        while (cki.KeyChar != 'q');
	}

	// Ereignisroutinen implementieren
	static void FsoChanged(object source, FileSystemEventArgs e) {
		Console.WriteLine("Datei " +  e.Name + " " + e.ChangeType);
	}

	static void FsoRenamed(object source, RenamedEventArgs e) {
		Console.WriteLine("Datei {0} umbenannt in {1}", e.OldName, e.Name);
	}
}
