using System;
class Prog {
    static void Main(string[] args) {
        foreach (string s in args) {
            Console.WriteLine(s);
            foreach (char c in s)
                Console.WriteLine(" " + c);
//            Console.WriteLine();
        }
        Console.ReadLine();
    }
}
