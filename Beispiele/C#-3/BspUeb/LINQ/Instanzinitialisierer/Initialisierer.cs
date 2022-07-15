using System;
using System.Collections.Generic;

class CT {
	public int i;
}
struct ST {
	public int i;
}

class Initialisierer {
	static void Main() {
		// Instanzinitialisierer
		CT ct = new CT() { i = 13 };
		ST st = new ST { i = 4711 };
		Console.WriteLine(ct.i + "\n" + st.i);

		//Listeninitialisierer
		List<int> il = new List<int>() { 1, 2, 3 };
		foreach (int eli in il)
			Console.Write(eli+" ");
		Console.ReadLine();
	}
}