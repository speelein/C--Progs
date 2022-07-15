using System;
class DM2EuroS {
    static void Main() {
		const decimal FAKTOR = 1.95583m;
        while (true) {
            Console.Write("DM-Betrag oder 0 zum Beenden: ");
            decimal euro = Convert.ToDecimal(Console.ReadLine());
            euro = euro / FAKTOR;
            if (euro <= 0)
                break;

            // Lösung mit arithmetischen Operatoren
            //decimal cent = euro % 1.0m;
            //euro = euro - cent;
            //cent = cent * 100;
            //Console.WriteLine("{0:f0} Euro und {1:f0} Cent\n", euro, cent);

            // Lösung mit Hilfe der Methoden Truncate() und Round() aus der Struktur Decimal
            decimal cent = Decimal.Round((euro % 1.0m) * 100);
            euro = Decimal.Truncate(euro);
            Console.WriteLine("{0} Euro und {1} Cent\n", euro, cent);
        }
    }
}