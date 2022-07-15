using System;
using System.Threading.Tasks;

class TaskResultDemo {
	const int N = 10_000;

    static double SampleMean(Object seed) {
	    var zzg = new Random((int)seed);
	    double erg = 0.0;
	    for (int j = 0; j < N; j++)
		    erg += zzg.NextDouble();
	    return erg / N;
    }

	static void Main() {
        //var task = new Task<double>(SampleMean, 13);
        //task.Start();
        //Task<double> task = Task.Factory.StartNew<double>(SampleMean, 13);
        Task<double> task = Task.Run<double>(() => SampleMean(13));

        // Parallele Arbeiten erledigen
        Console.WriteLine("Stichprobenmittel = " + task.Result);
	}
}