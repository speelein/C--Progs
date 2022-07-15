using System;
delegate void DemoGate(int w);
class AnoMethLambda {
	static char c = 'A';
	static void Main() {
		DemoGate DemoVar = w => {
			for (int i = 1; i <= w; i++)
				Console.Write(c);
			Console.WriteLine();
		};
		DemoVar(3);
	}
}
