using System;
using System.Threading.Tasks;

class TaskContinueWhenAll {
	const int ANZ = 1_000;
	const int N = 100;

	static double SampleMean(Object obj) {
		Random zzg = new Random((int)obj);
		double erg = 0.0;
		for (int j = 0; j < N; j++)
			erg += zzg.NextDouble();
		return erg/N;
	}

    static void Summary(Task<double>[] sampleMeanTaskArray) {
		double x;
		int n = sampleMeanTaskArray.Length;
		double sum = 0.0;
		double sq = 0.0;
		for (int j = 0; j < n; j++) {
			x = sampleMeanTaskArray[j].Result;
			sum += x;
			sq += x*x;
		}
		double mean = sum / n;
		// Varianzberechnung per Verschiebungsformel
		double variance = (sq - (sum * sum / n)) / (n - 1);
		double sd = Math.Sqrt(variance);
		Console.WriteLine("\nAnzahl = {0,25:d}\nUmfang = {1,25:d}\nMittel = {2,25:f7}"+
			"\nVarianz = {3,24:f7}\nStandardabweichung = {4,13:f7}", n, N, mean, variance, sd);
	}

	static void Main() {
		long start = DateTime.Now.Ticks;
		var sampleMeanTaskArray = new Task<double>[ANZ];
		for (int i = 0; i < ANZ; i++)
			sampleMeanTaskArray[i] = Task.Factory.StartNew<double>(SampleMean, i);

		//Action<Task<double>[]> summaryDelegate = new Action<Task<double>[]>(Summary);

		Task summaryTask = Task.Factory.ContinueWhenAll<double>(sampleMeanTaskArray, Summary);

		summaryTask.Wait();
		Console.WriteLine("\nZeit im Sek.: " + (DateTime.Now.Ticks - start) / 1.0e7);

		Console.ReadLine();
	}
}