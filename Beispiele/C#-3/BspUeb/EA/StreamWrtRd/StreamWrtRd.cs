using System;
using System.IO;

class StreamWrtRd {
	static void Main() {
		String name = "demo.txt";
		StreamWriter sw = new StreamWriter(name);
		sw.WriteLine(4711);
		sw.WriteLine(3.1415926);
		sw.WriteLine("Nicht übel");
		sw.Close();

		StreamReader sr = new StreamReader(
						  new FileStream(name, FileMode.Open, FileAccess.Read));
		Console.WriteLine("Inhalt der Datei {0}\n", ((FileStream)sr.BaseStream).Name);
		for (int i = 0; sr.Peek() >= 0; i++ ) {
			Console.WriteLine("{0}:\t{1}", i, sr.ReadLine());
		}
		Console.ReadLine();
	}
}
