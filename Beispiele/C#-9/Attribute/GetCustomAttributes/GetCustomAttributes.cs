using System;

[Obsolete] [Serializable]
class Teller {
	public static void Tell() {
		Console.WriteLine("Hallo!");
	}
}

class Prog {
	static void Main() {
		Type type = typeof(Teller);
		Attribute[] atar = Attribute.GetCustomAttributes(type, false);
		foreach (Attribute at in atar)
			Console.WriteLine(at);
	}
}
