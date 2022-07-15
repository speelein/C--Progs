#nullable enable annotations
#nullable enable warnings
using System;
class Prog {
    string s;
    static void Main() {
        Prog p = new Prog();
        string? sl = null;
        p.s = sl;
        int len = p.s.Length;
        Console.WriteLine(len);
    }
}



