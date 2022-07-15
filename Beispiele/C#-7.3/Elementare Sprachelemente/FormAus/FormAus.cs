using System;
class FormAus {
    static void Main() {
        int i = 4711, j = 471, k = 47, m = 4;
        Console.WriteLine($"Rechtsbündig:\n\ti = {i,4}\n\tj = {j,4}\n\tk = {k,4}\n\tm = {m,4}" +
                          $"\nLinksbündig:\n\t{i,-4} (i)\n\t{j,-4} (j)\n\t{k,-4} (k)\n\t{m,-4} (m)");
    }
}