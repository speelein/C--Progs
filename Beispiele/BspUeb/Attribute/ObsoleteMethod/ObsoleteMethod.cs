using System;

class Klasse {
	[Obsolete("Der Support f?r Tell() l?uft aus. Benutzen Sie bitte TellEx()")]
	public static void Tell() {
		Console.WriteLine("Hallo!");
	}

	public static void TellEx() {
		Console.WriteLine("Hallo, Wilhelm!");
	}
}

class Prog {
	static void Main() {
		Klasse.Tell();
        Console.ReadLine();
	}
}
