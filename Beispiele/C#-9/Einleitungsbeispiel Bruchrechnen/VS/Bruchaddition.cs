using System;

class Bruchaddition {
    static void Main() {
        Bruch b1 = new Bruch(), b2 = new Bruch();

        Console.WriteLine("1. Bruch");
        b1.Frage();
        b1.Kuerze();
        b1.Zeige();

        Console.WriteLine("\n2. Bruch");
        b2.Frage();
        b2.Kuerze();
        b2.Zeige();

        Console.WriteLine("\nSumme");
        b1.Addiere(b2);
        b1.Zeige();
        Console.ReadLine();
    }
}