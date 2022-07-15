using System;
using System.Diagnostics;

class GgtDiff {
    static void Main() {
        long ggt = 0;
        Console.WriteLine("GGT-Bestimmung mit Euklid (Differenz)\n");
        Console.Write("Erste Zahl:\t");
        long a = Math.Abs(Convert.ToInt32(Console.ReadLine()));
        Console.Write("\nZweite Zahl:\t");
        long b = Math.Abs(Convert.ToInt32(Console.ReadLine()));
        if (a * b == 0)
            return;
        var sw = new Stopwatch();
        sw.Start();
        do {
            if (a == b)
                ggt = a;
            else
                if (a > b)
                    a -= b;
                else
                    b -= a;
        } while (ggt == 0);
        sw.Stop();
        Console.WriteLine("\nGGT:\t\t" + ggt);
        Console.WriteLine("\nBenöt. Zeit:\t" + sw.ElapsedMilliseconds + " Millisek.");
        Console.Write("\nEnter zum Beenden");
        Console.ReadLine();
    }
}
