using System;
using System.Reflection;

[Obsolete("Benutzen Sie bitte NewTeller.")]
public class Teller {
	[Obsolete("Der Support für Tell() läuft aus. Benutzen Sie bitte TellEx().")]
	public static void Tell() {
		Console.WriteLine("Hallo!");
	}
}

class Prog {
	static void Main() {
		Type typeTeller = typeof(Teller);
		Type typeObsolete = typeof(ObsoleteAttribute);

		if (Attribute.IsDefined(typeTeller, typeObsolete))
			Console.WriteLine("Der Typ {0}\n ist obsolet", typeTeller.Name);

		MemberInfo[] mi = typeTeller.FindMembers(MemberTypes.Method,
			BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, Type.FilterName, "Tell");
		if (Attribute.IsDefined(mi[0], typeObsolete))
			Console.WriteLine("\nDie Methode {0}\n ist obsolet", mi[0].Name);
		Console.Read();
	}
}
