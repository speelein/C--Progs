﻿using System;
class FormAus {
    static void Main() {
        int i = 4711, j = 471, k = 47, m = 4;
        Console.WriteLine("Rechtsbündig:\n\ti = {0,4}\n\tj = {1,4}\n\tk = {2,4}\n\tm = {3,4}" + 
                          "\nLinksbündig:\n\t{0,-4} (i)\n\t{1,-4} (j)\n\t{2,-4} (k)\n\t{3,-4} (m)",
                          i, j, k, m);
    }
}