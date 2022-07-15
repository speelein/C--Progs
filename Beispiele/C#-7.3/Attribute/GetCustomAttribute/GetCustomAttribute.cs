using System;
using System.Reflection;

class Teller {
	[Obsolete("Benutzen Sie bitte TellEx().")]
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
		MemberInfo[] members	 = tt.FindMembers(MemberTypes.Method,
			BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, Type.FilterName, "*");
		Console.WriteLine("Obsolete-Prüfung für die Methoden des Typs {0}:", tt.FullName);
		foreach (MemberInfo mi in members) {
			attrib = Attribute.GetCustomAttribute(mi, typeof(ObsoleteAttribute));
			if (attrib != null) {
				Console.WriteLine("\nDie Methode {0}() ist obsolet.", mi.Name);
				Console.WriteLine("Message: " + (attrib as ObsoleteAttribute).Message);
			} else
				Console.WriteLine("\nDie Methode {0}() ist noch aktuell.", mi.Name);
		}
	}
	
	static void Main() {
		ObsoleteMethodCheck(typeof(Teller));
	}
}
