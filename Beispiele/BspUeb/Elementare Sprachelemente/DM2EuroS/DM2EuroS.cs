using System;
class DM2EuroS {
    static void Main() {
        const double FAKTOR = 1.95583;
        while (true) {
            Console.Write("DM-Betrag oder 0 zum Beenden: ");
            double euraw = Convert.ToDouble(Console.ReadLine()) / FAKTOR;
            if (euraw <= 0)
                break;
            long euro = (long)euraw;
            byte cent = (byte)((euraw - euro) * 100 + 0.5);
            Console.WriteLine(euro + " Euro und " + cent + " Cent\n");
        }
    }
}