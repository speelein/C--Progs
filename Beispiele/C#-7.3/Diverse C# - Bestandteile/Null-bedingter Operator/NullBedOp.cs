using System;

delegate void DemoGate(int w);

class NullBedOp {

	static void SagA(int w) {
		for (int i = 1; i <= w; i++)
			Console.Write('A');
		Console.WriteLine();
	}

	static void Main() {

		// Beispiel mit traditioneller lösung
		String[] ass = null; // new String[] { "eins", "zwei" };
		int len1 = -1;
		if (ass != null && ass[1] != null)
			len1 = ass[1].Length;
		Console.WriteLine("Länge: " + len1);

		// Operator ?.
		String s = null;
		int? sl = s?.Length;

		// Operator ?[
		String ass1 = ass?[1];

		// Moderne Lösung des Einstigbeispiels
		int? len1b = ass?[1]?.Length;
		Console.WriteLine("Länge: " + len1b);

		// Kombination mit dem Null-Sammeloperator
		int len1c = ass?[1]?.Length ?? -1;

		// Delegatenaufruf übei einen Null-bedingten Operator
		DemoGate demoVar = null; // new DemoGate(SagA);
		demoVar?.Invoke(2);
	}
}

