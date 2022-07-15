using System;
using System.Threading.Tasks;

class TaskResultDemo {
	const int SG = 10000;

	static double SampleMean() {
		Random zzg = new Random();
		double erg = 0.0;
		for (int j = 0; j < SG; j++)
			erg += zzg.NextDouble();
		return erg / SG;
	}

	static void Main() {
		Task<double> task = Task.Factory.StartNew<double>(SampleMean);
		Console.WriteLine("Stichprobenmittel = " + task.Result);
	}
}