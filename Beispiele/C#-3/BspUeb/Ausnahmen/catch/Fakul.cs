using System;
using System.Text;

class Fakul {
	static String instr;

	static int Kon2Int() {
		int arg = -1;
		try {
			arg = Convert.ToInt32(instr);
		} catch (FormatException) {
			String str = instr;
			bool ok = false;
			while (str.Length > 1 && !ok) {
				str = str.Substring(0, str.Length - 1);
				ok = Int32.TryParse(str, out arg);
			}
			if (ok)
				instr = str;
			else
				arg = -1;
		} catch (OverflowException) {}
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
		} else
			instr = args[0];
		int argument = Kon2Int();
		if (argument != -1) {
			double fakul = 1.0;
			for (int i = 1; i <= argument; i++)
				fakul = fakul * i;
			Console.WriteLine("Fakultät von {0}: {1}", instr, fakul);
		} else
			Console.WriteLine("Keine ganze Zahl im Intervall [0, 170]: " + instr);
		Console.Read();
	}
}
