using System;
class Prog {
	static void Main() {
		const int LEN = 1000000;
		const int MXR = 1000000;
		const int NCAND = 10;

		int[] iar = new int[LEN];
		var zzg = new Random();
		for (int i = 0; i < LEN; i++)
			iar[i] = zzg.Next(MXR);

		long time = DateTime.Now.Ticks;
		time = DateTime.Now.Ticks;
		for (int i = 0; i < NCAND; i++)
			Console.WriteLine("i=" + i + ", Index=" +
				Array.IndexOf(iar, zzg.Next(MXR)));
		time = DateTime.Now.Ticks - time;
		Console.WriteLine("\nBenöt. Zeit für die einfache Suche:\t" +
				  time / 1.0e4 + " Millisek.");

		time = DateTime.Now.Ticks;
		Array.Sort(iar);
		time = DateTime.Now.Ticks - time;
		Console.WriteLine("\nBenöt. Zeit für das Sortieren:\t\t" +
				  time / 1.0e4 + " Millisek.");

		time = DateTime.Now.Ticks;
		for (int i = 0; i < NCAND; i++)
			Console.WriteLine("i=" + i + ", Index=" +
				Array.BinarySearch(iar, zzg.Next(MXR)));
		time = DateTime.Now.Ticks - time;
		Console.WriteLine("\nBenöt. Zeit für die binäre Suche:\t" +
				  time / 1.0e4 + " Millisek.");
	}
}
