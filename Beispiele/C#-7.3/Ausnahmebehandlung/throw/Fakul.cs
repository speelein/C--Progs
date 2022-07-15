using System;

class Fakul {
	static int Kon2Int(String instr) {
		int arg;
		arg = Int32.Parse(instr);
		if (arg < 0  ||  arg > 170)
			throw new ArgumentOutOfRangeException(nameof(instr), arg, 
				"Argument ausserhalb [0, 170]");
		else
			return arg;
	}

	static void Main(string[] args) {
		int argument = -1;
		if (args.Length == 0) {
			Console.WriteLine("Kein Argument angegeben");
			Console.Read();
			Environment.Exit(1);
		}
        try {
			argument = Kon2Int(args[0]);
        } catch (Exception e) {
	        Console.WriteLine(e.Message);
			Console.Read();
			Environment.Exit(1);
        }

		double fakul = 1.0;
		for (int i = 1; i <= argument; i++)
				fakul = fakul * i;
		Console.WriteLine("Fakultät von {0}: {1}", args[0], fakul);
		Console.Read();
	}
}
