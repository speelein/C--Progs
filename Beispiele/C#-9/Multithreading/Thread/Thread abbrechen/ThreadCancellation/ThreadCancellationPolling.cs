using System;
using System.Threading;

public class ThreadCancellationPolling {
	void Write(String s) {
		for (int i = 0; i < s.Length; i++) {
			Console.Write(s[i]);
			Thread.Sleep(100);
		}
		Console.WriteLine();
	}

    public void Run(object obj) {
        var ct = (CancellationToken)obj;
	    for (int i = 0; i < 5; i++) {
		    Write("Rumoren im Runner, i = " + i);
		    Thread.Sleep(1000);
		    if (ct.IsCancellationRequested) {
			    Console.WriteLine(" Tschüss!");
			    break;
		    }
	    }
    }

	static void Main() {
		using var cts = new CancellationTokenSource();
		var runner = new ThreadCancellationPolling();
		var t = new Thread(new ParameterizedThreadStart(runner.Run));
		t.Start(cts.Token);
		Thread.Sleep(8000);
		cts.Cancel();
	}
}
