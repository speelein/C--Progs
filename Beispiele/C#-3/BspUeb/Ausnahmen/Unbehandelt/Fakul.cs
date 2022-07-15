using System;

class Fakul {
	static String instr;

	static int Kon2Int() {
		int arg = Convert.ToInt32(instr);
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
		} else
			instr = args[0];
		int argument = Kon2Int();
		if (argument != -1) {
			double fakul = 1.0;
			for (int i = 1; i <= argument; i++)
					fakul = fakul * i;
			Console.WriteLine("Fakultät von {0}: {1}", instr, fakul);
		}
		else
			Console.WriteLine("Keine ganze Zahl im Intervall [0, 170]: "
							  + instr);
		Console.Read();
	}
}
