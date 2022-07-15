using System;

[Obsolete("Benutzen Sie bitte MyNewClass")]
class MyClass {
	public static void Tell() {
		Console.WriteLine("Hallo!");
	}
}

class Prog {
	static void Main() {
		if (Attribute.IsDefined(typeof(MyClass),
								typeof(ObsoleteAttribute)))
			Console.WriteLine("MyClass ist obsolet");
		Console.Read();
	}
}
