using System;

class Fakul {
    static int Kon2Int(string instr) {
	    int arg;
	    try {
		    arg = Convert.ToInt32(instr);
		    if (arg < 0  || arg > 170)
			    throw new BadFakulArgException("Wert ausselhalb [0, 170]", instr, 3, arg);
		    else
			    return arg;
	    }
        catch (OverflowException e) {
            throw new BadFakulArgException(e.Message, instr, 2, -1);
        }
        catch (FormatException) {
		    throw new BadFakulArgException("Fehler beim Konvertieren", instr, 1, -1);
	    }
    }

    static void Main(string[] args) {
	    int argument = -1;
	    if (args.Length == 0) {
		    Console.WriteLine("Kein Argument angegeben");
		    Environment.Exit(1);
	    }
	    try {
		    argument = Kon2Int(args[0]);
	    }
        catch (BadFakulArgException e) {
		    Console.WriteLine(e.Message);
            Console.WriteLine("Fehlertyp: " + e.FehlerTyp);
		    if (e.FehlerTyp == 3)
			    Console.WriteLine("Wert: "+e.Wert);
            else
                Console.WriteLine("String: " + e.Eingabe);
            Console.ReadLine();
            Environment.Exit(1);
	    }
	    double fakul = 1.0;
	    for (int i = 1; i <= argument; i++)
		    fakul = fakul * i;
	    Console.WriteLine("Fakultät: " + fakul);
        Console.ReadLine();
    }
}
