using System;
using System.Reflection;

class MyClass {
	[Obsolete("Der Support für Tell() läuft aus. Benutzen Sie bitte TellEx()")]
	public static void Tell() {
		Console.WriteLine("Hallo!");
	}
	public static void TellEx() {
		Console.WriteLine("Hallo, Wilhelm!");
	}
}

class Prog {
	static void ObsoleteMethodCheck(Type tt) {
		Attribute attrib;
		MemberInfo[] member = tt.FindMembers(MemberTypes.Method,
			BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, Type.FilterName, "*");
		Console.WriteLine("Obsolete-Prüfung für die Methoden der Klasse {0}:", tt.FullName);
		foreach (MemberInfo mi in member) {
			attrib = Attribute.GetCustomAttribute(mi, typeof(ObsoleteAttribute));
			if (attrib != null) {
				Console.WriteLine("\nDie Methode {0}() ist obsolet", mi.Name);
				Console.WriteLine("Message: " + (attrib as ObsoleteAttribute).Message);
			} else
				Console.WriteLine("\nDie Methode {0}() ist noch aktuell", mi.Name);
		}
	}
	
	static void Main() {
		ObsoleteMethodCheck(typeof(MyClass));
		Console.Read();
	}
}
