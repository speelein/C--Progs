using System;
using System.Text;

class StringIntern {
	public static void Main() {
		const int anz = 50_000, len = 50, vergl = 5;
		var sb = new StringBuilder();
		var ran = new Random();
		String[] sar = new String[anz];
		for (int i = 0; i < anz; i++) {
			for (int j = 0; j < len; j++)
				sb.Append((char)(65 + ran.Next(26)));
			sar[i] = sb.ToString();
			sb.Remove(0, len);
		}

		long start = DateTime.Now.Ticks; // DateTime außerhalb der Messung laden
		start = DateTime.Now.Ticks;
		int hits = 0;
		// anz * vergl Inhaltsvergleiche
		for (int i = 0; i < anz; i++)
			for (int n = 1; n <= vergl; n++)
				if (sar[i] == sar[ran.Next(anz)])
					hits++;
		Console.WriteLine((anz * vergl) + " Inhaltsvergleiche (" + hits +
				" hits) benötigen " + ((DateTime.Now.Ticks - start) / 1.0e4) +
				" Millisekunden");

		start = DateTime.Now.Ticks;
		hits = 0;
		// Internalisieren
		for (int j = 1; j < anz; j++)
			sar[j] = String.Intern(sar[j]);
		Console.WriteLine("Zeit für das Internalisieren: " +
				((DateTime.Now.Ticks - start) / 1.0e4) + " Millisekunden");
		// anz * vergl Adressvergleiche
		for (int i = 0; i < anz; i++)
			for (int n = 1; n <= vergl; n++)
				if ((Object)sar[i] == sar[ran.Next(anz)])
					hits++;
		Console.WriteLine((anz * vergl) + " Adressvergleiche (" + hits +
						  " hits) benötigen (inkl. Internalisieren) " +
						  ((DateTime.Now.Ticks - start) / 1.0e4) + " Millisekunden");
	}
}
