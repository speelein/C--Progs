using System;

class Teller {
	[Obsolete("Benutzen Sie bitte TellEx().")]
	public static void Tell() {
		Console.WriteLine("Hallo!");
	}

	public static void TellEx() {
		Console.WriteLine("Hallo, Wilhelm!");
	}
}

class Prog {
	static void Main() {
		Teller.Tell();
	}
}






