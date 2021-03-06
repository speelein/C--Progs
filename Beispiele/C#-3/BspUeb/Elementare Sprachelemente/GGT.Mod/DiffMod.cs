using System;

class GgtMod {
    static void Main() {
        Console.WriteLine("ggT-Bestimmung mit Euklid (Modulo)\n");
        Console.Write("Erste Zahl:   ");
        long ggt = Math.Abs(Convert.ToInt32(Console.ReadLine()));
        Console.Write("\nZweite Zahl:  ");
        long divisor = Math.Abs(Convert.ToInt32(Console.ReadLine()));
        if (ggt * divisor == 0)
            return;
        long rest;
        long zeit = DateTime.Now.Ticks;
        do {
            rest = ggt % divisor;
            ggt = divisor;
            divisor = rest;
        } while (rest > 0);
        zeit = DateTime.Now.Ticks - zeit;
        Console.WriteLine("\nggT:          " + ggt);
        Console.WriteLine("\nBen?t. Zeit:  " + zeit / 1.0e4 + " Millisek.");
        Console.Write("\nEnter zum Beenden");
        Console.ReadLine();
    }
}
