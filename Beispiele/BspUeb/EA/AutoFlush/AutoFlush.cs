using System;
using System.IO;

class AutoFlushDemo {
	static void Main() {
		long zeit = DateTime.Now.Ticks;;
		StreamWriter sw = new StreamWriter("demo.txt");
//		sw.AutoFlush = true;
		for (int i = 1; i < 30000; i++) {
			sw.WriteLine(i);
		}
		sw.Close();
		Console.WriteLine("Zeit: "+((DateTime.Now.Ticks-zeit)/1.0e4)+" Millisek.");
        Console.ReadLine();
	}
}
