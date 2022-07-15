using System;
class UniRand {
	static void Main() {
		const int drl = 10_000;
		int[] uni = new int[5];
		Random zzg = new Random();
		for (int i = 0; i < drl; i++)
			uni[zzg.Next(5)]++;
		Console.WriteLine("Absolute Häufigkeiten:");
		for (int i = 0; i < 5; i++)
			Console.Write(uni[i] + " ");
		Console.WriteLine("\n\nRelative Häufigkeiten:");
		for (int i = 0; i < 5; i++)
			Console.Write((double)uni[i] / drl + " ");
	}
}
