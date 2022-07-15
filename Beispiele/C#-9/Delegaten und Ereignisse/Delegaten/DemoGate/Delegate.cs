using System;
using System.Collections.Generic;


delegate void DemoGate(int w);

class DeleDemo {
	static void SagA(int w){
		for (int i = 1; i <= w; i++)
			Console.Write('A');
		Console.WriteLine();
	}
	static void SagB(int w) {
		for (int i = 1; i <= w; i++)
			Console.Write('B');
		Console.WriteLine();
	}

	static void SagWas(DemoGate dg, int wdh) {
		dg(wdh);
	}

	static int EvenLower(int first, int second) {
		if (first % 2 == second % 2)
			return first.CompareTo(second);
		if (first % 2 == 0)
			return -1;
		return 1;
	}

	static void Main() {
		var deleVar = new DemoGate(SagA);
		deleVar(3);
		Console.WriteLine();

		// Hier entsteht ein neues(!) Delegatenobjekt mit verlängerter Aufrufliste:
		deleVar += new DemoGate(SagB);
		// Delegatenobjekt aufrufen
		deleVar(3);
		Console.WriteLine();

		deleVar -= new DemoGate(SagA);
		// Delegatenobjekt als Aktualparameter verwenden
		SagWas(deleVar, 5);

		Console.WriteLine();
        var intList = new List<int>();
        intList.Add(5); intList.Add(4); intList.Add(3);
        intList.Add(2); intList.Add(1); intList.Add(6);
		intList.Sort(EvenLower);
		foreach (int i in intList)
			Console.Write(" " + i);
	}
}
