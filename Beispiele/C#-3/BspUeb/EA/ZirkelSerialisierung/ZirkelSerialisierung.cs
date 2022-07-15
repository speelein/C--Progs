using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
struct A {
	public B bref;
	public string name;
}

[Serializable]
class B {
	public C cref;
	public string name;
}

[Serializable]
class C {
	public A aref;
	public string name;
}

class ZirkelSerialisierung {
	static void Main() {
		A a = new A(); B b = new B(); C c = new C();
		a.bref = b; a.name = "a-Obj";
		b.cref = c; b.name = "b-Obj";
		c.aref = a; c.name = "c-Obj";

		FileStream fs = new FileStream("demo.bin", FileMode.Create);
		IFormatter bifo = new BinaryFormatter();
		bifo.Serialize(fs, a);

		fs.Position = 0;
		A na = (A) bifo.Deserialize(fs);
		Console.WriteLine("Rekonstruiert: " + na.bref.cref.aref.name);
		Console.ReadLine();
	}
}