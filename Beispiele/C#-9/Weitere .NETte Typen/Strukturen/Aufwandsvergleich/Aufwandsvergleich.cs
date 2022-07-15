using System;

class Aufwandsvergleich {
    const int anzahl = 1_000_000;

    static void MakeStructArray() {
        Console.WriteLine("{0,-50}{1,20}","MB vor Struct-Array-Erstellung:",
          GC.GetTotalMemory(false) / 1048576);
        long st = DateTime.Now.Ticks;
        SPunkt[] arc = new SPunkt[anzahl];
        for (int i = 0; i < anzahl; i++)
            arc[i] = new SPunkt(i, i);
        st = DateTime.Now.Ticks - st;
        Console.WriteLine("{0,-50}{1,20}", "Benötigte Zeit für den Struktur-Array:",
                          (st / 1.0e4) + " Millisek.");
        Console.WriteLine("{0,-50}{1,20}", "MB nach Struct-Array-Erst., noch in Methode:",
                          GC.GetTotalMemory(false) / 1048576);
    }

    static void MakeClassArray() {
        Console.WriteLine("\n{0,-50}{1,20}", "MB vor Class-Array-Erstellung:",
                  GC.GetTotalMemory(false) / 1048576);
        long ct = DateTime.Now.Ticks;
        CPunkt[] arc = new CPunkt[anzahl];
        for (int i = 0; i < anzahl; i++)
            arc[i] = new CPunkt(i, i);
        ct = DateTime.Now.Ticks - ct;
        Console.WriteLine("{0,-50}{1,20}", "Benötigte Zeit für den Klassen-Array:",
                          (ct / 1.0e4) + " Millisek.");
        Console.WriteLine("{0,-50}{1,20}", "MB nach Class-Array-Erstellung, noch in Methode:",
                  GC.GetTotalMemory(true) / 1048576);
    }

    static void Main() {
        long wzeit = DateTime.Now.Ticks; // Verhindert einen verzerrten Wert der 1. Messung
        MakeStructArray();
        Console.WriteLine("{0,-50}{1,20}", "MB nach Struct-Array-Erstellung, nach Rückkehr:",
                          GC.GetTotalMemory(true) / 1048576);
        MakeClassArray();
        Console.WriteLine("{0,-50}{1,20}", "MB nach Class-Array-Erstellung, nach Rückkehr:",
                          GC.GetTotalMemory(true) / 1048576);
    }
}
