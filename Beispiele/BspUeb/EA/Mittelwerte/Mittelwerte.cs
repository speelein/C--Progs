using System;
using System.IO;

class Mittelwerte {
    static void Main(String[] args) {
        char[] sep = new char[] { ';' };
        String s = "";
        String[] tokens = {""};
        StreamReader sr = null;
        try {
            sr = new StreamReader(args[0]);
            s = sr.ReadLine();
            tokens = s.Split(sep);
        } catch {
            Console.WriteLine("Kein Dateiname angegeben, Datei nicht vorhanden oder Datei leer.");
            Console.ReadLine();
            Environment.Exit(1);
        }
        Console.WriteLine("Mittelwertsberechnung für die Datei " + args[0] + "\n");
        int nVar = tokens.Length;
        double[] means = new double[nVar];
        int[] nValid = new int[nVar];
        int n = 0;
        do {
            n++;
            tokens = s.Split(sep);
            if (tokens.Length != nVar) {
                Console.WriteLine("Warnung: Falsche Anzahl von Werten in Zeile " + n);
                Console.WriteLine(" \"" + s + "\"");
            }
            for (int i = 0; i < nVar; i++) {
                try {
                    means[i] += Convert.ToDouble(tokens[i]);
                    nValid[i]++;
                } catch {
                    Console.WriteLine("Warnung: Token " + (i + 1) + " in Zeile " + n + " ist keine Zahl.");
                }
            }
        } while ((s = sr.ReadLine()) != null);

        Console.WriteLine("\n            Variable           Mittelwert         Valide Werte");
        for (int i = 0; i < means.Length; i++)
            Console.WriteLine("{0, 20} {1, 20:f3} {2, 20}", i + 1, means[i] / nValid[i], nValid[i]);
        Console.ReadLine();
    }
}
