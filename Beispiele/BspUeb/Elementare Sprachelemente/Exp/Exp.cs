using System;
class Exp {
    static void Main() {
        Console.Write("Argument: ");
        double arg = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("exp(" + arg + ") = " + Math.Exp(arg));
        Console.WriteLine("\nDr�cken Sie die Enter-Taste zum Beenden.");
        Console.ReadLine();
    }
}