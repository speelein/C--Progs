using System;

delegate void DemoGate(int w);

class AnoMeth {
	static void Main() {
		char c = 'A';
		DemoGate DemoVar =
			delegate (int w) {
				for (int i = 1; i <= w; i++)
					Console.Write(c);
				Console.WriteLine();
			};
		DemoVar(3);
	}
}
