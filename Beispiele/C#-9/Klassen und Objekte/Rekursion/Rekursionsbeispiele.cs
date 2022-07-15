using System;
class Prog {
	static void Main() {
		Console.Write("Finonacci-Zahl (1) oder Fakultät (2) berechnen? ");
		int typ = Convert.ToInt32(Console.ReadLine());

		if (typ == 1) {
			Console.Write("\nFibonacci-Argument (Minimum 0): ");
			int fiboArg = Convert.ToInt32(Console.ReadLine());
			Rekursion.Fibonacci(fiboArg);
		} else {
			Console.Write("\nFakultäts-Argument zwischen 2 und 170: ");
			int fakulArg = Convert.ToInt32(Console.ReadLine());
			Rekursion.Fakul(fakulArg);
		}
	}
}
