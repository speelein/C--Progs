using System;
class BruchRechnung {
	static void Main() {
		Bruch[] b = new Bruch[3];
		b[0] = new Bruch(2, 3, "b[0] = ");
		b[1] = (Bruch) b[0].Clone();
		b[1].Zeige();
		b[2] = new Bruch(3, 5, "b[2] = ");
		Console.WriteLine("Sortiert:");
		Array.Sort(b);
		foreach (Bruch br in b)
			br.Zeige();
        Console.Read();
	}
}
