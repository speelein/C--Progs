using System;
using System.Diagnostics;

public class Rekursion {
    // Paul Frischknecht (2021)
    // Rekursive und iterative Berechnung der Fibonacci-Zahl
    public static void Fibonacci(int fiboNummer) {
        long anzahl = 0;  // z�hlt die Methodenaufrufe bei der rekursiven Methode
        Stopwatch uhr = new Stopwatch();

        uhr.Start();
        Console.WriteLine($"Rekursiv berechnete Fibonacci-Zahl von {fiboNummer}:\t {Fibr(fiboNummer)}");
        uhr.Stop();
        Console.WriteLine($"Berechnet in {uhr.Elapsed}");
        Console.WriteLine($"Anzahl Methodenaufrufe: {anzahl}"); // Gibt die Anzahl Methodenaufrufe aus

        uhr.Restart();
        Console.WriteLine($"Iterativ berechnete Fibonacci-Zahl von {fiboNummer}:\t {Fibi(fiboNummer)}");
        uhr.Stop();
        Console.WriteLine($"Berechnet in {uhr.Elapsed}");

        // Fibonacci-Zahl mittels Rekursion berechnen
        long Fibr(int n) {
            anzahl += 1; // z�hlt die Methodenaufrufe
            if (n < 2)
                return n;  // Null oder Eins
            return Fibr(n - 2) + Fibr(n - 1);
        }

        // Fibonacci-Zahl mittels for-Schleife berechnen
        long Fibi(int n) {
            long[] aFib = { -1, 1, 0 };  //Initialisierung so, dass es f�r n=0 oder n=1 auch klappt
            for (int i = 0; i <= n; i++) {
                aFib[2] = aFib[0] + aFib[1];
                aFib[0] = aFib[1];
                aFib[1] = aFib[2];
            }
            return aFib[2];
        }
    }

    // Rekursive Berechnung der Fakult�t
    public static void Fakul(int argument) {
        double FakulRek(int arg) {
            if (arg < 0)
                return double.NaN;
            if (arg > 170)
                return double.PositiveInfinity;

            if (arg == 0 || arg == 1)
                return 1;
            else
                return arg * FakulRek(arg - 1);
        }
        Console.WriteLine($"Fakult�t von {argument}: " + FakulRek(argument));
    }
}
