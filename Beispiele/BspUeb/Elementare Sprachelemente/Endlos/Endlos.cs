using System;
class Endlos {
    static void Main() {
        int i = 0;
        double d = 1.0;
        // besser: while (Math.Abs(d - 0.0) > 1.0e-14) {
        while (d != 0.0) {
            i++;
            d -= 0.1;
            Console.WriteLine("i = {0}, d = {1}", i, d);
        }
        Console.WriteLine("Fertig!");
    }
}