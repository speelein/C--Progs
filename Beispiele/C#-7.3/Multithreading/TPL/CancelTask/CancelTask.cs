using System;
using System.Threading;
using System.Threading.Tasks;

class Program {
    //static CancellationTokenSource cts2 = new CancellationTokenSource();
    //static CancellationToken ct2 = cts2.Token;

    const int MAXIT = 10000;

    static void Punktieren(Object token) {
        var ct = (CancellationToken)token;
        Console.WriteLine("Aufgabe in Bearbeitung");
        for (int i = 0; i < MAXIT; i++) {
            Thread.Sleep(500);
            Console.Write(".");
            if (ct.IsCancellationRequested) {
                Console.WriteLine("\nSignal zum Abbrechen erhalten\n");
                ct.ThrowIfCancellationRequested();
                //break;
            }
        }
    }

    //static void Punktieren(CancellationToken ct) {
    //    Console.WriteLine("Aufgabe in Bearbeitung");
    //    for (int i = 0; i < MAXIT; i++) {
    //        Thread.Sleep(500);
    //        Console.Write(".");
    //        if (ct.IsCancellationRequested) {
    //            Console.WriteLine("\nSignal zum Abbrechen erhalten\n");
    //            ct.ThrowIfCancellationRequested();
    //        }
    //    }
    //}

    static void Main() {
        var cts = new CancellationTokenSource();
		CancellationToken ct = cts.Token;

        Task task = Task.Factory.StartNew(Punktieren, ct, ct);
        //Task task = Task.Factory.StartNew(() => Punktieren(ct));
        Console.WriteLine("Aufgabe gestartet. Zustand:     " + task.Status + ".\nStoppen mit Enter\n");
		Console.ReadLine();

        Console.WriteLine("\nZustand der Aufgabe vor Cancel: " + task.Status);
        cts.Cancel();
        Console.WriteLine("Signal zum Abbrechen gesetzt.\n");

        try {
			task.Wait();
		} catch (AggregateException ae) {
			foreach (Exception ie in ae.InnerExceptions)
				Console.WriteLine("Innere Ausnahme: " + ie);
	    } finally {
            cts.Dispose();
        }
        Console.WriteLine("Aufgabe abgebrochen. Zustand:   "+task.Status);
    }
}