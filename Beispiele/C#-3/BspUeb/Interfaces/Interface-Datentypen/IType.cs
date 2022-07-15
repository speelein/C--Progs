using System;
interface IType {
	string SagWas();
}
class K1 : IType {
	public string SagWas() { return "K1"; }
}
class K2 : IType {
	public string SagWas() { return "K2"; }
}
struct S : IType {
	public string SagWas() { return "S"; }
}
class Prog {
	static void Main() {
		IType[] ida = {new K1(), new K2(), new S()};
		foreach (IType idin in ida)
			Console.WriteLine(idin.SagWas());
		Console.Read();
	}
}
