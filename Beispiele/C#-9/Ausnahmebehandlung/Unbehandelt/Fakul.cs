using System;

class Fakul {
	static int Kon2Int(string instr) {
		int arg = Int32.Parse(instr);
		if (arg >= 0  &&  arg <= 170)
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
		int argument = Kon2Int(args[0]);
		if (argument != -1) {
			double fakul = 1.0;
			for (int i = 1; i <= argument; i++)
					fakul = fakul * i;
			Console.WriteLine("Fakultät von {0}: {1}", args[0], fakul);
		}
		else
			Console.WriteLine("Keine ganze Zahl im Intervall [0, 170]: " + args[0]);
	}
}
