using System;
class CBit {
    static void Main() {
        char cbit;
        Console.Write("Zeichen: ");
        cbit = Convert.ToChar(Console.ReadLine());
        Console.Write("Unicode: ");
        for (int i = 15; i >= 0; i--) {
            if ((1 << i & cbit) != 0)
                Console.Write("1");
            else
                Console.Write("0");
        }
        Console.WriteLine();
        Console.ReadLine();
    }
}