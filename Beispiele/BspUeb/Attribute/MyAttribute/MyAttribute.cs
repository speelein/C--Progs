using System;
 
public class MyAttribute : Attribute {
	private int level;
	public MyAttribute(int level_) {
		level = level_;
	}
	public int Level {
		get {
			return level;
		}
	}
}

[MyAttribute(13)]
[Obsolete("Useless class")]
class SomeClass {
	public string Dummy {get {return "Dummy";}}
}

class Prog {
	static void Main() {
		Type type = typeof(SomeClass);
		Console.WriteLine("Benutzerdefinierte Attribute der Klasse "+type.FullName);
        object[] atv = type.GetCustomAttributes(false);
        for (int i = 0; i < atv.Length; i++) {
			Console.Write(" i= "+i+" "+atv[i]);
            if (atv[i] is MyAttribute)
                Console.WriteLine(" (Level = " + (atv[i] as MyAttribute).Level+ ")");
            else
                Console.WriteLine();
		}
        Console.ReadLine();
    }
}

