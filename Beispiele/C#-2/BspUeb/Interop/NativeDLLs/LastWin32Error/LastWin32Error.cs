using System;
using System.Runtime.InteropServices;

class NativeDLLs {
	[DllImport("kernel32.dll", SetLastError = true)]
	static extern bool MoveFile(string quelle, string ziel);

	static void Main() {
		string quelle = @"C:\Windows\System32\notepad.exe";
		string ziel = @"C:\Windows\System32\notebad.exe";
		if (!MoveFile(quelle, ziel))
			Console.WriteLine("Fehler " + Marshal.GetLastWin32Error() +
												" bei MoveFile");
		else
			Console.WriteLine("MoveFile erfolgreich");
		Console.ReadLine();
	}
}