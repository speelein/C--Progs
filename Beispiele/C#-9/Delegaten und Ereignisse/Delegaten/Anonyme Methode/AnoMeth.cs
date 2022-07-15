using System;

delegate void DemoGate(int w);

class AnoMeth {
	static void Main() {
		char c = 'A';
		DemoGate deleDemo =
			delegate (int w) {
				for (int i = 1; i <= w; i++)
					Console.Write(c);
				Console.WriteLine();
			};
		deleDemo(3);
	}
}
