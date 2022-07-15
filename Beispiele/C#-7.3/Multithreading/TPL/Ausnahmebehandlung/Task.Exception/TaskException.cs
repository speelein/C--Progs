using System;
using System.Threading;
using System.Threading.Tasks;

public class TaskException {
    static void Main() {
        var t1 = Task.Factory.StartNew(() => {
            Console.WriteLine("Thrower started");
            throw new Exception("Bang");
        }).ContinueWith(t => {
            Console.WriteLine(t.Exception.InnerException.Message);
        }, TaskContinuationOptions.OnlyOnFaulted);

        Thread.Sleep(100);
        t1.Wait();
        Console.WriteLine("No exception observed");
    }
}