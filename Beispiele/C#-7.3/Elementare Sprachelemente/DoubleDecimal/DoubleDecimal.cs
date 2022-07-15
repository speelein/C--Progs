using System;
class DoubleDecimal {
	static void Main() {
		Console.WriteLine("Binäre versus dezimale Gleitkommaarithmetik im Vergleich:");
		Console.WriteLine("  1,3 + 1,3 + ... (1 Mrd mal)\n");

		int anz = 1000000000;
		double exDouble = 1300000000;
		decimal exDecimal = 1300000000m;

		double d = 0.0;
		long zeit = DateTime.Now.Ticks;
		for (int i = 0; i < anz; i++)
			d += 1.3;
		zeit = DateTime.Now.Ticks - zeit;
		Console.WriteLine("double:\n  Abweichung:\t" + (d - exDouble));
		Console.WriteLine("  Benöt. Zeit:\t" + zeit/1.0e4 + " Millisek.");
		
		decimal dec = 0.0m;
		zeit = DateTime.Now.Ticks;
		for (int i = 0; i < anz; i++)
			dec += 1.3m;
		zeit = DateTime.Now.Ticks - zeit;
		Console.WriteLine("\n\ndecimal:\n  Abweichung:\t" + (dec - exDecimal));
		Console.WriteLine("  Benöt. Zeit:\t" + zeit/1.0e4 + " Millisek.");
        Console.ReadLine();
	}
}
