using System;

class Fakul {
	static int Kon2Int(ref String instr) {
		int arg = -1;
		try {
			arg = Convert.ToInt32(instr);
			if (arg < 0  || arg > 170)
				throw new BadFakulArgException("Wert außerhalb [0, 170]", instr, 4, arg);
			else
				return arg;
		} catch (ArgumentNullException e) {
			throw new BadFakulArgException("Argument ist null", null, 1, -1, e);
		} catch (FormatException e) {
			String str = instr;
			bool ok = false;
			while (str.Length > 1 && !ok) {
				str = str.Substring(0, str.Length - 1);
				ok = Int32.TryParse(str, out arg);
			}
			if (ok) {
				instr = str;
				return arg;
			} else
				throw new BadFakulArgException("Fehler beim Konvertieren", instr, 2, -1, e);
		} catch (OverflowException e) {
			throw new BadFakulArgException("Integer-Überlauf", instr, 3, -1, e);
		}
	}

	static void Main(string[] args) {
		int argument = -1;
		if (args.Length == 0) {
			Console.WriteLine("Kein Argument angegeben");
			Console.Read();
			Environment.Exit(1);
		}

		try {
			argument = Kon2Int(ref args[0]);
		}
		catch (BadFakulArgException e) {
			Console.WriteLine("Message:\t" + e.Message);
			Console.WriteLine("Fehlertyp:\t{0}\nZeichenfolge:\t{1} ", e.Type, e.Input);
			Console.WriteLine("Wert:    \t" + e.Value);
			if (e.InnerException != null)
				Console.WriteLine("Orig. Message:\t" + e.InnerException.Message);
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
