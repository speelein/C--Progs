using System;
 
[AttributeUsage(AttributeTargets.Class, Inherited=false)]
public class NonsenseAttribute : Attribute {
    public NonsenseAttribute(int level_) {
		Level = level_;
	}
    public int Level { get; }
}

[Serializable] [NonsenseAttribute(13)]
class Dummy {
}

class Prog {
	static void Main() {
		Type type = typeof(Dummy);
		Console.WriteLine("Benutzerdefinierte Attribute der Klasse {0}:", type.FullName);
		Attribute[] atar = Attribute.GetCustomAttributes(type, false);
   		foreach (Attribute at in atar) {
			Console.Write(" "+at);
			if (at is NonsenseAttribute)
				Console.WriteLine(" (Level: {0})", (at as NonsenseAttribute).Level);
			else
				Console.WriteLine();
		}
    }
}