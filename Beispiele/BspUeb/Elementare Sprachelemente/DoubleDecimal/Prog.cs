using System;
class Prog {
	static void Main() {
		Console.WriteLine("Binäre versus dezimale Gleitkommaarithmetik im Vergleich:");
		Console.WriteLine("  1,3 + 1,3 + ... (10000000 mal)\n");

		double d = 0.0;
		long zeit = DateTime.Now.Ticks;
		for (int i = 0; i < 10000000; i++)
			d += 1.3;
		zeit = DateTime.Now.Ticks - zeit;
		Console.WriteLine("double:\n  Abweichung:\t"+(d - 13000000));
		Console.WriteLine("  Benöt. Zeit:\t" + zeit/1.0e4 + " Millisek.");
		
		decimal dec = 0.0m;
		zeit = DateTime.Now.Ticks;
		for (int i = 0; i < 10000000; i++)
			dec += 1.3m;
		zeit = DateTime.Now.Ticks - zeit;
		Console.WriteLine("\n\ndecimal:\n  Abweichung:\t"+(dec - 13000000));
		Console.WriteLine("  Benöt. Zeit:\t" + zeit/1.0e4 + " Millisek.");
        Console.ReadLine();
	}
}
