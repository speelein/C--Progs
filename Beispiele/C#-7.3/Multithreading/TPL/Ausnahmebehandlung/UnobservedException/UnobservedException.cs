using System;
using System.Threading;
using System.Threading.Tasks;

public class UnObservedException {
    static void Main() {
        Task.Factory.StartNew(() => {
            Console.WriteLine("Thrower started");
            throw new Exception("Bang");
        });
        //.ContinueWith(t => {
        //     Console.WriteLine(t.Exception.InnerException.Message);
        // }, TaskContinuationOptions.OnlyOnFaulted);
        Thread.Sleep(100);
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("No exception observed");
     }
}