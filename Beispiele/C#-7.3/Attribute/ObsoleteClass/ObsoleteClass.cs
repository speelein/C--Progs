using System;

//[Obsolete]
[Obsolete("Benutzen Sie bitte NewTeller.")]
public class Teller {
	public static void Tell() {
		Console.WriteLine("Hallo!");
	}
}

public class NewTeller {
	public static void Tell() {
		Console.WriteLine("Hallo, Wilhelm!");
	}
}

class Prog {
	static void Main() {
        Teller.Tell();
        NewTeller.Tell();
        Console.Read();
	}
}



