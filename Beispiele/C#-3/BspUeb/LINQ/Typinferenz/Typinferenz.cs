using System;

class Typinferenz {
	static void Main() {
		var i = 13;
		var d = 3.14;
		Console.WriteLine("Wert: " + i +
			"\nTyp:  " + i.GetType());
		Console.WriteLine("\nWert: " + d +
			"\nTyp:  " + d.GetType());
		Console.ReadLine();
	}
}