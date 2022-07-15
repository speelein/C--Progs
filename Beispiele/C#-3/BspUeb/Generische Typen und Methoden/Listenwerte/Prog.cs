using System;
using System.Collections;
using System.Collections.Generic;
class Prog {
	static void Main() {
		const int N = 1000000;
		List<int> gli = new List<int>();
		long vorher = DateTime.Now.Ticks;
		for (int i = 0; i < N; i++)
			gli.Add(i);
		long diff = DateTime.Now.Ticks - vorher;
		Console.WriteLine("Zeit in Millisek. für List<int>: " + diff / 1.0e4);
		ArrayList ali = new ArrayList();
		vorher = DateTime.Now.Ticks;
		for (int i = 0; i < N; i++)
			ali.Add(i);
		diff = DateTime.Now.Ticks - vorher;
		Console.WriteLine("Zeit in Millisek. für ArrayList: " + diff / 1.0e4);
		Console.Read();
	}
}