using System;

class Aufwandsvergleich {
	static void Main() {
        const int ANZ = 1_000_000;

        // Zeitmessung vorbereiten
        long wzeit = DateTime.Now.Ticks;

        long st = DateTime.Now.Ticks;
        SPunkt[] arp = new SPunkt[ANZ];
        for (int i = 0; i < ANZ; i++)
            arp[i] = new SPunkt(i, i);
        GC.Collect();
        st = DateTime.Now.Ticks - st;
        Console.WriteLine("\nBenöt. Zeit für den Struktur-Array:\t" + st / 1.0e4 + " Millisek.");

        long ct = DateTime.Now.Ticks;
        CPunkt[] arc = new CPunkt[ANZ];
        for (int i = 0; i < ANZ; i++)
            arc[i] = new CPunkt(i, i);
        GC.Collect();
        ct = DateTime.Now.Ticks - ct;
        Console.WriteLine("\nBenöt. Zeit für den Klassen-Array:\t" + ct / 1.0e4 + " Millisek.");

        Console.ReadLine();
    }
}
