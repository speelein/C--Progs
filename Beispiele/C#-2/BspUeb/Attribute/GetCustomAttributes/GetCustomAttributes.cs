using System;

[Obsolete("Benutzen Sie bitte MyNewClass")]
class MyClass {
    public static void Tell() {
        Console.WriteLine("Hallo!");
    }
}

class Prog {
	static void Main() {
        Type type = typeof(MyClass);
        foreach (Attribute at in type.GetCustomAttributes(false))
            if (at is ObsoleteAttribute) {
                Console.WriteLine("MyClass ist obsolet");
                Console.WriteLine((at as ObsoleteAttribute).Message);
//                Console.WriteLine(((ObsoleteAttribute)at).Message);
            }
        Console.ReadLine();
    }
}
