// Primzahlen ermitteln per Ochsentour
using System;
class Primitiv {
    static void Main() {
        bool tg;
        ulong i, mtk, zahl;
        Console.WriteLine("Einfacher Primzahlendetektor\n");
        while (true) {
            Console.Write("Zu untersuchende positive Zahl oder 0 zum Beenden: ");
            try {
                zahl = Convert.ToUInt64(Console.ReadLine());
            } catch {
                Console.WriteLine("\aKeine Zahl (im zulässigen Bereich)!\n");
                Console.ReadLine();
                continue;
            }
            if (zahl == 0)
	            break;

            tg = false;
            mtk = (ulong) Math.Sqrt(zahl);	//Maximaler Teiler-Kandidat
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
