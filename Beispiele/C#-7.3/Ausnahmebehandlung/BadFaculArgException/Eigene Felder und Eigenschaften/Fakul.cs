using System;

class Fakul {
    static int Kon2Int(ref String instr) {
	    int arg = -1;
	    try {
		    arg = Convert.ToInt32(instr);
	    } catch (ArgumentNullException e) {
		    throw new BadFaculArgException("Kein Argument vorhanden", null, 1, -1, e);
        } catch (FormatException e) when (Double.TryParse(instr, out double d)) {
            arg = (int)d;
            if (arg == d)
                instr = arg.ToString();
            else
                throw new BadFaculArgException("Fehler beim Konvertieren", instr, 2, -1, e);
        } catch (FormatException e) {
    	    throw new BadFaculArgException("Fehler beim Konvertieren", instr, 2, -1, e);
	    } catch (OverflowException e) {
		    throw new BadFaculArgException("Ganzzahl-‹berlauf", instr, 3, -1, e);
	    }

        if (arg < 0 || arg > 170)
            throw new BadFaculArgException("Wert auﬂerhalb [0, 170]", instr, 4, arg);
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
		    argument = Kon2Int(ref args[0]);
            double fakul = 1.0;
            for (int i = 1; i <= argument; i++)
                fakul = fakul * i;
            Console.WriteLine("Fakult‰t von {0}: {1}", args[0], fakul);
            Console.Read();
        } catch (BadFaculArgException e) {
		    Console.WriteLine($"Message:\t{e.Message}");
		    Console.WriteLine($"Fehlertyp:\t{e.Type}\nEingabe:\t{e.Input} ");
		    Console.WriteLine($"Wert:\t\t{e.Value}");
		    if (e.InnerException != null)
			    Console.WriteLine($"Orig. Message:\t{e.InnerException.Message}");
		    Console.Read();
		    Environment.Exit(1);
	    }
    }
}
