using System;
using System.Diagnostics;

class GgtMod {
    static void Main() {
        Console.WriteLine("GGT-Bestimmung mit Euklid (Modulo)\n");
        Console.Write("Erste Zahl:   ");
        long ggt = Math.Abs(Convert.ToInt32(Console.ReadLine()));
        Console.Write("\nZweite Zahl:  ");
        long divisor = Math.Abs(Convert.ToInt32(Console.ReadLine()));
        if (ggt * divisor == 0)
            return;
        long rest;
        var sw = new Stopwatch();
        sw.Start();
        do {
            rest = ggt % divisor;
            ggt = divisor;
            divisor = rest;
        } while (rest > 0);
        sw.Stop();
        Console.WriteLine("\nGGT:          " + ggt);
        Console.WriteLine("\nBenöt. Zeit:  " + sw.ElapsedMilliseconds + " Millisek.");
        Console.Write("\nEnter zum Beenden");
        Console.ReadLine();
    }
}
