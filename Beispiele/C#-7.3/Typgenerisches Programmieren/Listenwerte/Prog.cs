using System;
using System.Collections;
using System.Collections.Generic;
class Prog {
	static void Main() {
		const int N = 1_000_000;

		// Zeitmessung vorbereiten
		long vorher = DateTime.Now.Ticks;

		var gli = new List<int>();
		vorher = DateTime.Now.Ticks;
		for (int i = 0; i < N; i++)
			gli.Add(i);
		long diff = DateTime.Now.Ticks - vorher;
		Console.WriteLine("Zeit in Millisek. für List<int>: " + diff / 1.0e4);

		var ali = new ArrayList();
		vorher = DateTime.Now.Ticks;
		for (int i = 0; i < N; i++)
			ali.Add(i);
		diff = DateTime.Now.Ticks - vorher;
		Console.WriteLine("Zeit in Millisek. für ArrayList: " + diff / 1.0e4);
	}
}