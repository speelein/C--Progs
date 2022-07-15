using System;
using System.Collections;
class ArrayListDemo {
	static void Main() {
		ArrayList al = new ArrayList();
		string s;
		Console.WriteLine("Was fällt Ihnen zu C#?\n");
		do {
			Console.Write(": ");
			s = Console.ReadLine();
			if (s.Length > 0)
				al.Add(s);
			else
				break;
		} while (true);
		
		Console.WriteLine("\nIhre Anmerkungen:");
		for(int i = 0; i < al.Count; i++)
			Console.WriteLine(al[i]);
        Console.ReadLine();
	}
}
