using System;

class MyClass {
	[Obsolete("Der Support für Tell() läuft aus. Benutzen Sie bitte TellEx()")]
	public static void Tell() {
		Console.WriteLine("Hallo!");
	}

	public static void TellEx() {
		Console.WriteLine("Hallo, Wilhelm!");
	}
}

class Prog {
	static void Main() {
		MyClass.Tell();
		Console.ReadLine();
	}
}
