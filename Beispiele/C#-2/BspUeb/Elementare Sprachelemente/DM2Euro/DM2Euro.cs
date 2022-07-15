using System;
class DM2Euro {
    static void Main() {
        const double FAKTOR = 1.95583;
        Console.Write("DM-Betrag: ");
        double euraw = Convert.ToDouble(Console.ReadLine()) / FAKTOR;
        long euro = (long)euraw;
        byte cent = (byte)((euraw - euro) * 100 + 0.5);
        Console.WriteLine(euro + " Euro und " + cent + " Cent");
        Console.Write("\nZum Beenden Enter drücken");
        Console.ReadLine();
    }
}
