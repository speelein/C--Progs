using System;

delegate void DemoGate(int w);

class LambdaDelegate {
    static char c = 'A';
    static void Main() {
        Predicate<int> evenAnon = delegate (int i) { return i % 2 == 0; };
        Predicate<int> even = i => i % 2 == 0;
        Console.WriteLine(even(3));

        DemoGate deleVar = w => {
            for (int i = 1; i <= w; i++)
                Console.Write(c);
            Console.WriteLine();
        };
        deleVar(3);
    }
}
