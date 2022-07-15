using System;
using System.Threading.Tasks;

class TaskResultDemo {
	const int sampleSize = 100_000_000;

	static double SampleMean() {
		var zzg = new Random();
		double erg = 0.0;
		for (int j = 0; j < sampleSize; j++)
			erg += zzg.NextDouble();
		return erg / sampleSize;
	}

	static void Main() {
        var task = new Task<double>(SampleMean);
        task.Start();
		Console.WriteLine("Task gestartet");
		//Task<double> task = Task.Factory.StartNew<double>(SampleMean);
		//Task<double> task = Task.Run<double>((Func<double>) SampleMean);

		// Parallele Arbeiten erledigen
		Console.WriteLine("Stichprobenmittel = " + task.Result);
	}
}