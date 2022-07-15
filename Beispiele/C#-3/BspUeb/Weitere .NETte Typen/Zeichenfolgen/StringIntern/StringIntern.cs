using System;
using System.Text;

class StringIntern {
	public static void Main() {
		const int ANZ = 50000, LEN = 20, N = 50;
		StringBuilder sb = new StringBuilder();
		Random ran = new Random();
		String[] sar  = new String[ANZ];
		for (int i = 0; i < ANZ; i++) {
			for (int j = 0; j < LEN; j++)
				sb.Append((char) (65 + ran.Next(26)));
			sar[i] = sb.ToString();
			sb.Remove(0, LEN);
		}

		long start = DateTime.Now.Ticks;
		int hits = 0;
		// N * ANZ Inhaltsvergleiche
		for (int n = 1; n <= N; n++)
			for (int i = 0; i < ANZ; i++)
				if (sar[i] == sar[ran.Next(ANZ)])
					hits++;
		Console.WriteLine((N * ANZ)+" Inhaltsvergleiche ("+hits+
				" hits) benoetigen "+((DateTime.Now.Ticks - start)/1.0e4)+
				" Millisekunden");

		start = DateTime.Now.Ticks;
		hits = 0;
		// Internieren
		for (int j = 1; j < ANZ; j++)
			sar[j] = String.Intern(sar[j]);
		Console.WriteLine("Zeit für das Internieren: " +
				((DateTime.Now.Ticks - start) / 1.0e4) + " Millisekunden");
		// N * ANZ Adressvergleiche
		for (int n = 1; n <= N; n++)
			for (int i = 0; i < ANZ; i++)
				if ((sar[i] as Object ) == sar[ran.Next(ANZ)])
					hits++;
		Console.WriteLine((N * ANZ)+" Adressvergleiche ("+hits+
				" hits) benoetigen (inkl. Internieren) "+
				((DateTime.Now.Ticks - start)/1.0e4)+" Millisekunden");
		Console.ReadLine();
	}
}