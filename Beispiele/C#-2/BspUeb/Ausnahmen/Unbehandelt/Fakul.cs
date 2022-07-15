using System;

class Fakul {
	static int Kon2Int(string instr) {
		int arg = Convert.ToInt32(instr);
		if (arg < 0  || arg > 170) {
			Console.WriteLine("Unzulässiges Argument: "+arg);
			Environment.Exit(1);
			return 0;
		}
		else
			return arg;
	}

	static void Main(string[] args) {
		int argument = -1;
		if (args.Length == 0) {
			Console.WriteLine("Kein Argument angegeben");
			Environment.Exit(1);
		}
		argument = Kon2Int(args[0]);
		double fakul = 1.0;
		for (int i = 1; i <= argument; i++)
				fakul = fakul * i;
		Console.WriteLine("Fakultät: " + fakul);
	}
}
