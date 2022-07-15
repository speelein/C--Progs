using System;
using System.Collections;

class Fakul {
    static int Kon2Int(ref String instr) {
	    int arg;
        try {
	        arg = Convert.ToInt32(instr);
        } catch (ArgumentNullException e) {
            var bfa = new BadFaculArgException("Kein Argument vorhanden", e);
            bfa.Data.Add("Input", instr);
            bfa.Data.Add("Type", 1);
            bfa.Data.Add("Value", -1);
            throw bfa;
        } catch (FormatException e) when (Double.TryParse(instr, out double d)) {
            arg = (int)d;
            if (arg == d)
                instr = arg.ToString();
            else {
                BadFaculArgException bfa = new BadFaculArgException("Fehler beim Konvertieren", e);
                bfa.Data.Add("Input", instr);
                bfa.Data.Add("Type", 2);
                bfa.Data.Add("Value", -1);
                throw bfa;
            }
        } catch (FormatException e) {
            BadFaculArgException bfa = new BadFaculArgException("Fehler beim Konvertieren", e);
            bfa.Data.Add("Input", instr);
            bfa.Data.Add("Type", 2);
            bfa.Data.Add("Value", -1);
            throw bfa;
        } catch (OverflowException e) {
            BadFaculArgException bfa = new BadFaculArgException("Ganzzahl-‹berlauf", e);
            bfa.Data.Add("Input", instr);
            bfa.Data.Add("Type", 3);
            bfa.Data.Add("Value", -1);
            throw bfa;
	    }
        if (arg < 0 || arg > 170) {
            BadFaculArgException bfa = new BadFaculArgException("Wert auﬂerhalb [0, 170]");
            bfa.Data.Add("Input", instr);
            bfa.Data.Add("Type", 4);
            bfa.Data.Add("Value", arg);
            throw bfa;
        } else
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
		    argument = Kon2Int(ref args[0]);
            double fakul = 1.0;
            for (int i = 1; i <= argument; i++)
                fakul = fakul * i;
            Console.WriteLine("Fakult‰t von {0}: {1}", args[0], fakul);
            Console.Read();
        } catch (BadFaculArgException e) {
            foreach (DictionaryEntry de in e.Data)
                Console.WriteLine($"{de.Key}\t:\t{de.Value}");
            if (e.InnerException != null)
    			Console.WriteLine($"Orig. Message:\t{e.InnerException.Message}");
            Console.WriteLine($"Wert = {e.Data["Value"]}");
            Console.Read();
		    Environment.Exit(1);
	    }
    }
}
