using System;
class SortSearch {
	static void Main() {
		const int len = 1_000_000;
		const int mxr = 1_000_000;
		const int nCand = 10;

		int[] iar = new int[len];
		Random zzg = new Random();
		for (int i = 0; i < len; i++)
			iar[i] = zzg.Next(mxr);

		long time = DateTime.Now.Ticks; // Verhindert einen verzerrten Wert der 1. Messung
		time = DateTime.Now.Ticks;
		for (int i = 0; i < nCand; i++)
			Console.WriteLine("i=" + i + ", Index=" +
				Array.IndexOf(iar, zzg.Next(mxr)));
		time = DateTime.Now.Ticks - time;
		Console.WriteLine("\nBenöt. Zeit für die einfache Suche:\t" +
				  time / 1.0e4 + " Millisek.");

		time = DateTime.Now.Ticks;
		Array.Sort(iar);
		time = DateTime.Now.Ticks - time;
		Console.WriteLine("\nBenöt. Zeit für das Sortieren:\t\t" +
						  time / 1.0e4 + " Millisek.\n");

		time = DateTime.Now.Ticks;
		for (int i = 0; i < nCand; i++)
			Console.WriteLine("i=" + i + ", Index=" +
				Array.BinarySearch(iar, zzg.Next(mxr)));
		time = DateTime.Now.Ticks - time;
		Console.WriteLine("\nBenöt. Zeit für die binäre Suche:\t" +
						  time / 1.0e4 + " Millisek.");
	}
}
