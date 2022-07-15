using System;
using System.Text;

class StringIntern {
	public static void Main() {
		const int ANZ = 50000, LEN = 50, N = 50;
		var sb = new StringBuilder();
		var ran = new Random();
		String[] sar  = new String[ANZ];
		for (int i = 0; i < ANZ; i++) {
			for (int j = 0; j < LEN; j++)
				sb.Append((char) (65 + ran.Next(26)));
			sar[i] = sb.ToString();
			sb.Remove(0, LEN);
		}

		// DateTime außerhalb der Messung laden
		long start = DateTime.Now.Ticks;

		start = DateTime.Now.Ticks;
		int hits = 0;
		// N * ANZ Inhaltsvergleiche
		for (int n = 1; n <= N; n++)
			for (int i = 0; i < ANZ; i++)
				if (sar[i] == sar[ran.Next(ANZ)])
					hits++;
		Console.WriteLine((N * ANZ)+" Inhaltsvergleiche ("+hits+
				" hits) benötigen "+((DateTime.Now.Ticks - start)/1.0e4)+
				" Millisekunden");

		start = DateTime.Now.Ticks;
		hits = 0;
		// Internalisieren
		for (int j = 1; j < ANZ; j++)
			sar[j] = String.Intern(sar[j]);
		Console.WriteLine("Zeit für das Internalisieren: " +
				((DateTime.Now.Ticks - start) / 1.0e4) + " Millisekunden");
		// N * ANZ Adressvergleiche
		for (int n = 1; n <= N; n++)
			for (int i = 0; i < ANZ; i++)
				if ( ((Object)sar[i]) == sar[ran.Next(ANZ)] )
					hits++;
		Console.WriteLine((N * ANZ)+" Adressvergleiche ("+hits+
				" hits) benötigen (inkl. Internalisieren) "+
				((DateTime.Now.Ticks - start)/1.0e4)+" Millisekunden");
		Console.ReadLine();
	}
}