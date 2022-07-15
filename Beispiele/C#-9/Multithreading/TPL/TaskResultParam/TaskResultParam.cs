using System;
using System.Threading.Tasks;

class TaskResultParam {
	const int sampleSize = 100_000_000;

    static double SampleMean(object seed) {
	    var zzg = new Random((int)seed);
	    double erg = 0.0;
	    for (int j = 0; j < sampleSize; j++)
		    erg += zzg.NextDouble();
	    return erg / sampleSize;
    }

    static void Main() {
        //var task = new Task<double>(SampleMean, 13);
        //task.Start();
        Task<double> task = Task.Factory.StartNew<double>(SampleMean, 13);
        Console.WriteLine("Task gestartet");
        // Parallele Arbeiten erledigen
        Console.WriteLine("Stichprobenmittel = " + task.Result);
        Console.WriteLine("Pseudozufall-Startwert = " + task.AsyncState);
    }
}