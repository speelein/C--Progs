using System;
using System.Threading.Tasks;

class TaskResultDemo {
	const int N = 10_000;

	static double SampleMean() {
		var zzg = new Random();
		double erg = 0.0;
		for (int j = 0; j < N; j++)
			erg += zzg.NextDouble();
		return erg / N;
	}

	static void Main() {
        //var task = new Task<double>(SampleMean);
        //task.Start();
        //Task<double> task = Task.Factory.StartNew<double>(SampleMean);
        Task<double> task = Task.Run<double>((Func<double>) SampleMean);

        // Parallele Arbeiten erledigen
        Console.WriteLine("Stichprobenmittel = " + task.Result);
	}
}