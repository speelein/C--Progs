using System;

delegate void HalloGate(int w);

class Sprecher {
	int n;
	public HalloGate HalloVar;
	public Sprecher(int w) {
		n = w;
	}
	public void Sprich() {
		if (HalloVar != null)
			HalloVar(n);
	}
}

class Prog {
	static void Muster1(int w){
		Console.Write("H");
		for (int i = 1; i <= w; i++)
			Console.Write("a");
		Console.WriteLine("llo!");
	}
	static void Muster2(int w){
		Console.Write("Hallo");
		for (int i = 1; i <= w; i++)
			Console.Write("!");
		Console.WriteLine();
	}
    static void Main() {
	    Sprecher h = new Sprecher(3);
	    // Hier entsteht ein Delegatenobjekt, das auf die statische Methode Muster1() zeigt:
	    h.HalloVar = new HalloGate(Muster1);
	    h.Sprich();
	    // Hier entsteht ein neues(!) Delegatenobjekt mit verlängerter Aufrufliste:
        h.HalloVar += new HalloGate(Muster2);
        h.Sprich();
        Console.ReadLine();
    }
}
