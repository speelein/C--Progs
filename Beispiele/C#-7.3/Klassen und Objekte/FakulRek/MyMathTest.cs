using System;
class Prog {
	static void Main() {
		int argument;
		Console.Write("Argument zwischen 2 und 170: ");
		argument = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Fakultät: " + MyMath.Fakul(argument));
	}	
}
