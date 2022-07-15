// Lösung von Paul Frischknecht

using System;

class Tupelmuster {
    static bool GenauZweiNachbarnGleich(int a1, int a2, int a3) =>
        (a1, a2, a3) switch {
            (0, _, 0) => false,
            (0, 0, 1) => true,
            (0, 1, 1) => true,
            (1, 0, 0) => true,
            (1, _, 1) => false,
            (1, 1, 0) => true
        };
    // a2 == a1 != (a2 == a3);

    static void Main() {
        for (int a1 = 0; a1 < 2; a1++)
            for (int a2 = 0; a2 < 2; a2++)
                for (int a3 = 0; a3 < 2; a3++)
                    Console.WriteLine($"{a1} {a2} {a3} -> {GenauZweiNachbarnGleich(a1, a2, a3)}");
    }
}
