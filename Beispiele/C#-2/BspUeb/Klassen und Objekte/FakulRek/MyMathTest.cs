using System;
class Prog {
	public static void Main() {
		int argument;
		Console.Write("Argument: ");
		argument = Convert.ToInt32(Console.ReadLine());
		if (argument > 0)
			Console.WriteLine("Fakult�t: " + MyMath.Fakul(argument));
        Console.WriteLine("\nBeenden mit Enter");
        Console.ReadLine();
	}	
}
