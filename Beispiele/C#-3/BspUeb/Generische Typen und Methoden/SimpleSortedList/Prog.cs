using System;
class Prog {
	static void Main() {
		SimpleSortedList<int> si = new SimpleSortedList<int>(5);
		si.Add(11);si.Add(2);si.Add(1);si.Add(4);
		int result;
		for (int i = 0; i < 4; i++)
			if (si.Get(i, out result))
				Console.WriteLine(result);
		Console.Read();
	}
}