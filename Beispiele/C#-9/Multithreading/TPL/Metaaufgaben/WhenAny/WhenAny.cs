using System;
using System.Threading;
using System.Threading.Tasks;

class WhenAnyDemo {
    static void SleepAndThrow(Object ii) {
        int i = (int)ii;
        Thread.Sleep(1000);
        throw new Exception("Task " + i + "Faulted");
    }

    static void Main() {
        Task t1 = Task.Factory.StartNew(SleepAndThrow, 1);
        Task t2 = Task.Factory.StartNew(SleepAndThrow, 2);
        Task<Task> t = Task.WhenAny(t1, t2);
        t.Wait();
        Console.WriteLine("Status von t: " + t.Status);
        Console.WriteLine("Zuerst fertig: " + t.Result.AsyncState +
            "\n   mit Status: " + t.Result.Status);
    }
}