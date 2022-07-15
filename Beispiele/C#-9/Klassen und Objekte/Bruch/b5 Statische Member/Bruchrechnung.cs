using System;
class Bruchrechnung {
    static void Main() {
        Bruch b = Bruch.BenDef("Startwert");
        if (b != null)
            b.Zeige();
        else
            Console.WriteLine("b zeigt auf null");
    }
}
