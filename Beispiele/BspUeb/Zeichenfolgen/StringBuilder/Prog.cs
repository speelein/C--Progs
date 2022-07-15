using System;
using System.Text;
class Prog {
    static void Main() {
        String s = "*";
        long vorher = DateTime.Now.Ticks;
        for (int i = 0; i < 10000; i++)
            s = s + "*";
        long diff = DateTime.Now.Ticks - vorher;
        Console.WriteLine("Zeit für String-Manipulation:\t\t" + diff / 1.0e4);

        StringBuilder t = new StringBuilder("*");
        vorher = DateTime.Now.Ticks;
        for (int i = 0; i < 10000; i++)
            t.Append("*");
        diff = DateTime.Now.Ticks - vorher;
        Console.WriteLine("Zeit für StringBuilder-Manipulation:\t" + diff / 1.0e4);
        Console.ReadLine();
    }
}