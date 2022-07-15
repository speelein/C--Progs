using System;
using System.Threading;
using System.Threading.Tasks;

class ExceptionAfterTimeout {
	static void Werfer() {
		Thread.Sleep(500);
		throw new Exception();
	}

	static void Main() {
		TaskScheduler.UnobservedTaskException +=
			(object sender, UnobservedTaskExceptionEventArgs eventArgs) => {
				Console.WriteLine("UnobservedTaskException-Handler");
                //eventArgs.SetObserved();
            };

		Task t = Task.Factory.StartNew(Werfer);

		try {
            t.Wait(50);
		} catch {
			Console.WriteLine("Diese Ausgabe wird nie erscheinen.");
		}

		Thread.Sleep(1000); // Die Aufgabe erhält Zeit zum Werfen der Ausnahme
        t = null;
        GC.Collect();
		for (int i = 0; i < 5; i++) {
			Thread.Sleep(500);
			Console.Write(i + " ");
		}
	}
}
