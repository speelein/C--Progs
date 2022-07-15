using System;
class BK {
	protected string x = "Bast";
	public void BM() {
		Console.WriteLine("x in BK-Methode:\t"+x);
	}
}
class AK : BK {
	new int x = 333;
	public void AM() {
		Console.WriteLine("x in AK-Methode:\t"+x);
		Console.WriteLine("base-x in AK-Methode:\t"+
		                   base.x);
	}
}
class Prog {
	static void Main() {
		AK ako = new AK();
		ako.BM();
		ako.AM();
        Console.ReadLine();
	}
}
