using System;

delegate void DemoGate(int w);

class LambdaDelegate {
    static char c = 'A';
    static void Main() {
        DemoGate demoVar = w => {
            for (int i = 1; i <= w; i++)
                Console.Write(c);
            Console.WriteLine();
        };
        demoVar(3);
    }
}
