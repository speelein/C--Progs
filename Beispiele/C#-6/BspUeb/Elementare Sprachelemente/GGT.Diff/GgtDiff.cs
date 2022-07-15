using System;

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
        long zeit = DateTime.Now.Ticks;
        do {
            if (a == b)
                ggt = a;
            else
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
        } while (ggt == 0);
        zeit = DateTime.Now.Ticks - zeit;
        Console.WriteLine("\nGGT:\t\t" + ggt);
        Console.WriteLine("\nBenöt. Zeit:\t" + zeit / 1.0e4 + " Millisek.");
        Console.Write("\nEnter zum Beenden");
        Console.ReadLine();
    }
}
