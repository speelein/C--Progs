using System;
class UniRand {
    static void Main() {
        const int DRL = 10000;
        int i;
        int[] uni = new int[5];
        Random zzg = new Random();
        for (i = 1; i <= DRL; i++)
            uni[zzg.Next(5)]++;
        Console.WriteLine("Absolute Häufigkeiten:");
        for (i = 0; i < 5; i++)
            Console.Write(uni[i] + " ");
        Console.WriteLine("\n\nRelative Häufigkeiten:");
        for (i = 0; i < 5; i++)
            Console.Write((double)uni[i] / DRL + " ");
        Console.ReadLine();
    }
}

