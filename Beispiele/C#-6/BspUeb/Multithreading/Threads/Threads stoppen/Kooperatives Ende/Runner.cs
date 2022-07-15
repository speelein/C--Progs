using System;
using System.Threading;

public class Runner {
	public bool Stopped { get; set; }

	void Write(String s) {
		for (int i = 0; i < s.Length; i++) {
			Console.Write(s[i]);
			Thread.Sleep(100);
		}
		Console.WriteLine();
	}

	public void Run() {
		try {
			for (int i = 0; i < 5; i++) {
				Write("Rumoren im Runner, i = " + i);
				Thread.Sleep(1000);
				if (Stopped) {
					Console.WriteLine(" Tschüss!");
					break;
				}
			}
		} catch (ThreadAbortException) {
				Console.WriteLine(" Autsch!");
		}
	}
}
