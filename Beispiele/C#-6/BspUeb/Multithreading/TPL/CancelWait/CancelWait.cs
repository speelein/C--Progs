using System;
using System.Threading;
using System.Threading.Tasks;

class CancelWait {
	CancellationTokenSource tokenSource;

	CancelWait(CancellationTokenSource tokS) {
		tokenSource = tokS;
	}

	void Run() {
		Thread.Sleep(5000);
		tokenSource.Cancel();
	}

	static void Dummy() {
		for (int i = 0; i < 10; i++) {
			Thread.Sleep(1000);
			Console.WriteLine(i);
		}
	}

	static void Main() {
		CancellationTokenSource cts = new CancellationTokenSource();
		CancellationToken ct = cts.Token;

		var runner = new CancelWait(cts);
		new Thread(runner.Run).Start();

		Task t = Task.Factory.StartNew(Dummy, ct);
		try {
			t.Wait(ct);
		} catch (Exception ex) {
			Console.WriteLine(ex.GetType());
		}
		Console.WriteLine("Hinter try");
	}
}