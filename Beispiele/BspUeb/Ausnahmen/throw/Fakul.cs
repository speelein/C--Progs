using System;

class Fakul {
    static int Kon2Int(string instr) {
	    int arg;
	    arg = Convert.ToInt32(instr);
	    if (arg < 0  || arg > 170)
		    throw new ArgumentOutOfRangeException("instr",
		      "Argument ausserhalb [0, 170]");
	    else
		    return arg;
    }

	static void Main(string[] args) {
		int argument = -1;
		if (args.Length == 0) {
			Console.WriteLine("Kein Argument angegeben");
			Environment.Exit(1);
		}
        try {
	        argument = Kon2Int(args[0]);
        } catch (Exception e) {
	        Console.WriteLine(e.Message);
	        Environment.Exit(1);
        }

		double fakul = 1.0;
		for (int i = 1; i <= argument; i++)
				fakul = fakul * i;
		Console.WriteLine("Fakultät: " + fakul);
	}
}
