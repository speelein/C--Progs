using System;

class Fakul {
	static int Kon2Int(ref String instr) {
		int arg = -1;
		try {
			arg = Int32.Parse(instr);
		} catch (FormatException) {
			String sk = instr;
			bool ok = false;
			while (sk.Length > 1 && !ok) {
				sk = sk.Substring(0, sk.Length - 1);
				ok = Int32.TryParse(sk, out arg);
			}
			if (ok)
				instr = sk;
			else
				return -2;

		} catch (OverflowException) {
			return -1;
		}
		if (arg >= 0 && arg <= 170)
			return arg;
		else
			return -1;
	}

	static void Main(string[] args) {
		if (args.Length == 0) {
			Console.WriteLine("Kein Argument angegeben");
			Console.Read();
			Environment.Exit(1);
		}
		int argument = Kon2Int(ref args[0]);
		if (argument >= 0) {
			double fakul = 1.0;
			for (int i = 1; i <= argument; i++)
				fakul = fakul * i;
			Console.WriteLine("Fakultät von {0}: {1}", args[0], fakul);
		} else
			if (argument == -1)
				Console.WriteLine("Keine ganze Zahl im Intervall [0, 170]: " + args[0]);
			else
				if (argument == -2)
					Console.WriteLine("Eingabefehler: " + args[0]);
	}
}
