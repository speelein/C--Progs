using System;
using System.Threading;

public class AbortForeign {
    void Write(string s) {
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
            }
        } catch (ThreadAbortException) {
            Console.WriteLine("Autsch!");
        }
    }

    static void Main() {
        var runner = new AbortForeign();
        var t = new Thread(runner.Run);
        t.Start();
        Thread.Sleep(8000);
        t.Abort();
    }
}
