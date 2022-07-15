// Primzahlen ermitteln per Ochsentour
// GUI-Version
using System;
using Microsoft.VisualBasic;
using System.Windows.Forms;

class PrimitivGUI {
	static void Main() {
		bool tg;
		ulong i, mtk, zahl;
		string ergebnis;
		while (true) {
			string input = Interaction.InputBox("Zu untersuchende Zahl >= 2:",
		                     "Einfacher Primzahlendetektor", "", 500, 300);
			// Wenn der Benutzer die InpuBox abbricht (cancel oder Kreuz in Titelzeile)
			// liefert InputBox() eine leere Zeichenfolge.
			if (input == "")
				break;

            if (!UInt64.TryParse(input, out zahl) || zahl < 2) {
                MessageBox.Show("Keine Zahl (im zulässigen Bereich)!", "Einfacher Primzahlendetektor", MessageBoxButtons.OK,
                                MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
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
				ergebnis = zahl + " ist keine Primzahl.\n(Teiler: " + i + ")";
			else
				ergebnis = zahl + " ist eine Primzahl.";
			MessageBox.Show(ergebnis, "Einfacher Primzahlendetektor", MessageBoxButtons.OK,
			                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
		}
		MessageBox.Show("Vielen Dank für den Einsatz dieser Software!",
		                "Einfacher Primzahlendetektor", MessageBoxButtons.OK);
	}
}
