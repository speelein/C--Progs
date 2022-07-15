// Primzahlen ermitteln ohne break und continue
using System;
class PrimitivOBC {
    static void Main() {
        bool tg;
        ulong i, mtk, zahl = 0;
        bool eingabeOK ;
        bool stopWhile = false;
        Console.WriteLine("Einfacher Primzahlendetektor\n");
        while (!stopWhile) {
            eingabeOK = true;
            Console.Write("Zu untersuchende ganze Zahl von 2 bis 2^63-1 oder 0 zum Beenden: ");
            try {
                zahl = Convert.ToUInt64(Console.ReadLine());
                if (zahl == 0)
                    stopWhile = true;
            } catch {
                Console.WriteLine("Keine Zahl (im zulässigen Bereich)!\n");
                eingabeOK = false;
            }
            if (zahl == 1) {
                Console.WriteLine("1 ist per Definition keine Primzahl.\n");
                eingabeOK = false;
            }
            if (eingabeOK && !stopWhile) {
                tg = false;
                mtk = (ulong)Math.Sqrt(zahl);	//Maximaler Teiler-Kandidat
                i = 2;
                while (i <= mtk && !tg) {
                    if (zahl % i == 0)
                        tg = true;
                    else
                        i++;
                }
                if (tg)
                    Console.WriteLine(zahl + " ist keine Primzahl (Teiler: " + i + ").\n");
                else
                    Console.WriteLine(zahl + " ist eine Primzahl.\n");
            }
        }
        Console.WriteLine("\nVielen Dank für den Einsatz dieser Software!");
    }
}