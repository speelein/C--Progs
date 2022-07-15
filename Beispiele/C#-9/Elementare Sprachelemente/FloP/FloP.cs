// Zur Genauigkeit der binären Gleitkommadarstellung (Floating - Precision)
using System;
class FloP {
    static void Main() {
        const double one = 1.0;
        double eps = 1.0;
        int i = 0;
        while (true) {
            i++;
            eps /= 2.0;
            if (!(one + eps > one))
                break;
            Console.WriteLine($"i = {i}:\t1.0 + {eps:E20} \t>\t1.0");
        }
        Console.WriteLine($"\ni = {i}:\t1.0 + {eps:E20} ergibt {1.0 + eps:E20}");
        Console.WriteLine("    ==>\t1.0 + {1:E20} nicht\t>\t1.0", i, eps);
        Console.WriteLine("\nDer Vergleich (" + eps + " > 0.0) ist " + (one > 0.0) + "!");
    }
}
