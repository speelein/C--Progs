using System;
using System.Text;

class StringIntern {
	public static void Main() {
		const int ANZ = 50000, LEN = 50, N = 5;
		var sb = new StringBuilder();
		var ran = new Random();
		String[] sar  = new String[ANZ];
		for (int i = 0; i < ANZ; i++) {
			for (int j = 0; j < LEN; j++)
				sb.Append((char) (65 + ran.Next(26)));
			sar[i] = sb.ToString();
			sb.Remove(0, LEN);
		}

		long start = DateTime.Now.Ticks; // DateTime au�erhalb der Messung laden

        start = DateTime.Now.Ticks;
		int hits = 0;
		// ANZ * N Inhaltsvergleiche
		for (int i = 0; i < ANZ; i++)
            for (int n = 1; n <= N; n++)
                if (sar[i] == sar[ran.Next(ANZ)])
					hits++;
		Console.WriteLine((ANZ * N)+" Inhaltsvergleiche ("+hits+
				" hits) ben�tigen "+((DateTime.Now.Ticks - start)/1.0e4)+
				" Millisekunden");

		start = DateTime.Now.Ticks;
		hits = 0;
		// Internalisieren
		for (int j = 1; j < ANZ; j++)
			sar[j] = String.Intern(sar[j]);
		Console.WriteLine("Zeit f�r das Internalisieren: " +
				((DateTime.Now.Ticks - start) / 1.0e4) + " Millisekunden");
        // ANZ * N Adressvergleiche
        for (int i = 0; i < ANZ; i++)
            for (int n = 1; n <= N; n++)
                if ((Object)sar[i] == sar[ran.Next(ANZ)])
                    hits++;
        Console.WriteLine((ANZ * N)+" Adressvergleiche ("+hits+
				" hits) ben�tigen (inkl. Internalisieren) "+
				((DateTime.Now.Ticks - start)/1.0e4)+" Millisekunden");
		Console.ReadLine();
	}
}