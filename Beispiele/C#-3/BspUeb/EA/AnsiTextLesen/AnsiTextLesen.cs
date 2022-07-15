using System;
using System.IO;
using System.Text;

class AnsiTextLesen {
	static String name = "AnsiText.txt";
	static void Main() {
		FileStream fs = new FileStream(name, FileMode.Open, FileAccess.Read);
		StreamReader sr = new StreamReader(fs);
		Console.WriteLine("Mit UTF8-Kodierung gelesen:");
		while (sr.Peek() >= 0)
			Console.WriteLine(sr.ReadLine());
		fs.Position = 0;
		sr = new StreamReader(fs, Encoding.Default);
		Console.WriteLine("\nMit ANSI-Kodierung gelesen:");
		while (sr.Peek() >= 0)
			Console.WriteLine(sr.ReadLine());
		Console.ReadLine();
	}
}

