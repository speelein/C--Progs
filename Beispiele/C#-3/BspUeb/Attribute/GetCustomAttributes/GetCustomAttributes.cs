using System;

[Obsolete] [Serializable]
class MyClass {
	public static void Tell() {
		Console.WriteLine("Hallo!");
	}
}

class Prog {
	static void Main() {
		Type type = typeof(MyClass);
		Attribute[] atar = Attribute.GetCustomAttributes(type, false);
		foreach (Attribute at in atar)
			Console.WriteLine(at);
		Console.Read();
	}
}
