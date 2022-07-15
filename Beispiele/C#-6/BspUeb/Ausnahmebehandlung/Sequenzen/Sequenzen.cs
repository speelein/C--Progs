using System;
class Sequenzen {
	static int Calc(String instr) {
		int erg = 0;
		try {
			Console.WriteLine("try-Block von Calc()");
			erg = Convert.ToInt32(instr);
			erg = 10 % erg;
		}
		catch (FormatException) {
			Console.WriteLine("FormatException-Handler in Calc()");
			//Console.WriteLine(e);
		}
		finally {
			Console.WriteLine("finally-Block von Calc()");
		}
		Console.WriteLine("Nach try-Anweisung in Calc()");
		return erg;
	}

	static void Main(string[] args) {
		try {
			Console.WriteLine("try-Block von Main()");
			Console.WriteLine("10 % " + args[0] + " = " + Calc(args[0]));
		}
		catch (ArithmeticException) {
			Console.WriteLine("ArithmeticException-Handler in Main()");
		}
		finally {
			Console.WriteLine("finally-Block von Main()");
		}
		Console.WriteLine("Nach try-Anweisung in Main()");
	}
}
