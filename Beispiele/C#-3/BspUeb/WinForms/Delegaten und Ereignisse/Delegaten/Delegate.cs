using System;

delegate void DemoGate(int w);

class DeleDemo {
	static void SagA(int w){
		for (int i = 1; i <= w; i++)
			Console.Write('A');
		Console.WriteLine();
	}
	static void SagB(int w){
		for (int i = 1; i <= w; i++)
			Console.Write('B');
		Console.WriteLine();
	}

	static void Main() {
		DemoGate DemoVar = new DemoGate(SagA);
		DemoVar(3);
		// Hier entsteht ein neues(!) Delegatenobjekt mit verlängerter Aufrufliste:
		DemoVar += new DemoGate(SagB);
		DemoVar(3);
		Console.Read();
	}
}
