using System;
delegate void DemoGate(int w);
class AnoMeth {
	static void Main() {
		DemoGate DemoVar =
			delegate(int w) {
				for (int i = 1; i <= w; i++)
					Console.Write('A');
				Console.WriteLine();
			};
		DemoVar(3); 
		Console.Read();
	}
}
