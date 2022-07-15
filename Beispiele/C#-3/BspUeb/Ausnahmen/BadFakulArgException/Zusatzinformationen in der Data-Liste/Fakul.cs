using System;
using System.Collections;

class Fakul {
	static String instr;
	
	static int Kon2Int() {
		int arg = -1;
		try {
			arg = Convert.ToInt32(instr);
			if (arg < 0 || arg > 170) {
				BadFakulArgException bfa = new BadFakulArgException("Wert ausselhalb [0, 170]");
				bfa.Data.Add("Input", instr);
				bfa.Data.Add("Type", 3);
				bfa.Data.Add("Value", arg);
				throw bfa;
			} else
				return arg;
		}
		catch (FormatException e) {
			String str = instr;
			bool ok = false;
			while (str.Length > 1 && !ok) {
				str = str.Substring(0, str.Length - 1);
				ok = Int32.TryParse(str, out arg);
			}
			if (ok) {
				instr = str;
				return arg;
			} else {
				BadFakulArgException bfa = new BadFakulArgException("Fehler beim Konvertieren", e);
				bfa.Data.Add("Input", instr);
				bfa.Data.Add("Type", 1);
				bfa.Data.Add("Value", -1);
				throw bfa;
			}
		} catch (OverflowException e) {
			BadFakulArgException bfa = new BadFakulArgException("Integer-Überlauf", e);
			bfa.Data.Add("Input", instr);
			bfa.Data.Add("Type", 2);
			bfa.Data.Add("Value", -1);
			throw bfa;
		}
	}

	static void Main(string[] args) {
		int argument = -1;
		if (args.Length == 0) {
			Console.WriteLine("Kein Argument angegeben");
			Console.Read();
			Environment.Exit(1);
		} else
			instr = args[0];

		try {
			argument = Kon2Int();
		}
		catch (BadFakulArgException e) {
			Console.WriteLine("Message\t:\t" + e.Message);
			foreach (DictionaryEntry de in e.Data) {
				Console.WriteLine("{0}\t:\t{1}", de.Key, de.Value);
			}
			//Console.WriteLine("Wert = {0}", e.Data["Value"]);
			if (e.InnerException != null)
				Console.WriteLine("Orig. Message:\t" + e.InnerException.Message);
			Console.Read();
			Environment.Exit(1);
		}
		double fakul = 1.0;
		for (int i = 1; i <= argument; i++)
			fakul = fakul * i;
		Console.WriteLine("Fakultät von {0}: {1}", instr, fakul);
		Console.Read();
	}
}
