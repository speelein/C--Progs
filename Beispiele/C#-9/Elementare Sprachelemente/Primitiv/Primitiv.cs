using System;
class Primitiv {
    static void Main() {
        bool tg;
        ulong i, mtk, zahl;
        Console.WriteLine("Einfacher Primzahlendetektor\n");
        while (true) {
            Console.Write("Zu untersuchende ganze Zahl von 2 bis 2^64-1 oder 0 zum Beenden: ");
            try {
                zahl = Convert.ToUInt64(Console.ReadLine());
            } catch {
                Console.WriteLine("Keine ganze Zahl (im zulässigen Bereich)!\n");
                continue;
            }
            if (zahl == 1) {
                Console.WriteLine("1 ist per Definition keine Primzahl.\n");
                continue;
            }
            if (zahl == 0)
                break;

            tg = false;
            mtk = (ulong)(Math.Sqrt(zahl) + 0.5); //Maximaler Teiler-Kandidat
            for (i = 2; i <= mtk; i++)
                if (zahl % i == 0) {
                    tg = true;
                    break;
                }

            if (tg)
                Console.WriteLine(zahl + " ist keine Primzahl (Teiler: " + i + ").\n");
            else
                Console.WriteLine(zahl + " ist eine Primzahl.\n");
        }
        Console.WriteLine("\nVielen Dank für den Einsatz dieser Software!");
        Console.ReadLine();
    }
}
