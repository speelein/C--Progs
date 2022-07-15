using System;
class Vater {
	protected string x = "Vast";
	public void VM() {
		Console.WriteLine("x in Vater-Methode:\t"+x);
	}
}
class Sohn : Vater {
	new int x = 333;
	public void SM() {
		Console.WriteLine("x in Sohn-Methode:\t"+x);
		Console.WriteLine("base-x in Sohn-Methode:\t"+
		                   base.x);
	}
}
class Prog {
	static void Main() {
		Sohn so = new Sohn();
		so.VM();
		so.SM();
        Console.ReadLine();
	}
}
