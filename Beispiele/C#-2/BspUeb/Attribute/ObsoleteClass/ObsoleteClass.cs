using System;

//[Obsolete]
[Obsolete("Benutzen Sie bitte MyNewClass")]
class MyClass {
	public static void Tell() {
		Console.WriteLine("Hallo!");
	}
}

class MyNewClass {
	public static void Tell() {
		Console.WriteLine("Hallo, Wilhelm!");
	}
}

class Prog {
	static void Main() {
        MyClass.Tell();
        MyNewClass.Tell();
        Console.ReadLine();
	}
}

