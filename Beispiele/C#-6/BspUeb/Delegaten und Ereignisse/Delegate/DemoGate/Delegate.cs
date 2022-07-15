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
		if (first % 2 == 0)
			if (second % 2 == 0)
				return first.CompareTo(second);
			else
				return -1;
		else
			if (second % 2 == 0)
			return 1;
		else
			return first.CompareTo(second);
	}

	static void Main() {
		DemoGate demoVar = new DemoGate(SagA);
		demoVar(3);
		Console.WriteLine();

		// Hier entsteht ein neues(!) Delegatenobjekt mit verlängerter Aufrufliste:
		demoVar += new DemoGate(SagB);
		// Delegatenobjekt aufrufen
		demoVar(3);
		Console.WriteLine();

		demoVar -= new DemoGate(SagA);
		// Delegatenobjekt als Aktualparameter verwenden
		SagWas(demoVar, 5);

		Console.WriteLine();
		var intList = new List<int> { 5, 4, 3, 2, 1, 6 };
		intList.Sort(EvenLower);
		foreach (int i in intList)
			Console.Write(" " + i);
	}
}
