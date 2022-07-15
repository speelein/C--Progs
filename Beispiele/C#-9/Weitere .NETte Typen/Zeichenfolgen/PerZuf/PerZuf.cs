using System;
class PerZuf {
	static void Main(string[] args) {
		int az, ez;
		if (args.Length < 2) {
			Console.WriteLine("\aBitte Vor- und Zunamen angeben.");
			return;
		}

        az = (int)args[0].ToUpper()[0];
        ez = (int)args[1].ToUpper()[args[1].Length - 1];
		
		Random zzg = new Random(az+ez);
        Console.WriteLine("Hallo "+args[0]+" "+args[1]+",\n");
        Console.WriteLine("vertrauen Sie der Zahl {0}!\n\nBeenden mit Enter", zzg.Next(100)+1);
        Console.ReadLine();
	}
}
