using System;
using System.Threading;

class PTS {
    static void TuWas(Object obj) {
        char c = (obj as String)[0];
        for (int i = 1; i < 100; i++) {
            Console.Write(c + " ");
            Thread.Sleep(10);
        }
    }
    static void Main() {
        Thread t = new Thread(new ParameterizedThreadStart(TuWas));
        t.Start("2");
        Thread.Sleep(500);
        Console.WriteLine("\nEnde Main");
    }
}
