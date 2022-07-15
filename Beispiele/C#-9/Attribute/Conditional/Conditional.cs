#define Trace
using System;
using System.Diagnostics;

public class Trace {
	[Conditional("Trace")]
	public static void Log(string msg) {
		Console.WriteLine(msg);
	}
}

class Condemo {
	static void Main() {
		int anzahl = 1_000;
		double zuf;
		Random ran = new Random();

		Trace.Log("Vor Beginn der Schleife");
		long vorher = DateTime.Now.Ticks;
		for (int i = 0; i < anzahl; i++) {
			zuf = ran.NextDouble();
			if (i % 100 == 0)
				Trace.Log(i.ToString());
		}
		long diff = DateTime.Now.Ticks - vorher;
		Trace.Log("Nach Beendigung der Schleife: " + diff / 1.0e4 + " Millisekunden");
	}
}
