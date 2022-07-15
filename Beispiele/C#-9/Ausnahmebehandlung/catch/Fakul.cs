using System;

class Fakul {
    static int Kon2Int(ref string instr) {
	    int arg;
        try {
            arg = Int32.Parse(instr);
        } catch (OverflowException) {
            return -1;
        } catch (FormatException) when (Double.TryParse(instr, out double d)) {
            arg = (int)d;
            if (arg == d) 
                instr = arg.ToString();
            else
                return -2;
        } catch (FormatException) {
            return -3;
        }
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
	    }
	    int argument = Kon2Int(ref args[0]);
        switch (argument) {
            case int arg when arg >= 0:
                double fakul = 1.0;
                for (int i = 1; i <= argument; i++)
                    fakul = fakul * i;
                Console.WriteLine("Fakultät von {0}: {1}", args[0], fakul);
                break;
            case -1:
                Console.WriteLine("Keine ganze Zahl im Intervall [0, 170]: " + args[0]);
                break;
            case -2:
                Console.WriteLine("Die Eingabe ist keine ganze Zahl: " + args[0]);
                break;
            case -3:
                Console.WriteLine("Die Eingabe ist nicht numerisch interpretierbar: " + args[0]);
                break;
        }
    }
}
