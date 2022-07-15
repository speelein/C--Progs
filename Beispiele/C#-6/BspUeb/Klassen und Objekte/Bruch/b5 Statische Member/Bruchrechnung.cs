using System;
class BruchRechnung {
    static void Main() {
        Bruch b = Bruch.BenDef("Benutzerdefiniert: ");
        if (b != null)
            b.Zeige();
        else
            Console.WriteLine("b zeigt auf null");
    }
}
