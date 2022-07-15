using System;
using System.Threading;
using System.Threading.Tasks;

class WhenAllDemo {
    static bool InternalExceptionHandler(Exception e) {
        Console.WriteLine(e.Message);
        return true;
    }

    static void Main() {
        Task t1 = Task.Run(() => {
            Thread.Sleep(1000);
            throw new Exception("Task 1 Faulted");
        });
        Task t2 = Task.Run(() => {
            Thread.Sleep(1000);
            throw new Exception("Task 2 Faulted");
        });
        Task t = Task.WhenAll(t1, t2);
        try {
            t.Wait();
        } catch (AggregateException ae) {
            ae.Handle(InternalExceptionHandler);
        }
        Console.WriteLine("Status von t: " + t.Status);
    }
}