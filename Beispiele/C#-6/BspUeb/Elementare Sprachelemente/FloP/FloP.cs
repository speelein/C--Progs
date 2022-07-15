// Zur Genauigkeit der binären Gleitkommadarstellung (Floating - Precision)
using System;

class FloP {
    static void Main() {
        const double ONE = 1.0;
        double eps = 1.0;
        int i = 0;
        while (true) {
            i++;
            eps = eps / 2.0;
            if (!(ONE + eps > ONE))
                break;
            Console.WriteLine("i = {0}:\t1.0 + {1:E20} \t>\t1.0", i, eps);
        }
        Console.WriteLine("\ni = {0}:\t1.0 + {1:E20} nicht\t>\t1.0", i, eps);
        Console.WriteLine("\nDer Vergleich (" + eps + " > 0.0) ist " + (ONE > 0.0) + "!");
    }
}
