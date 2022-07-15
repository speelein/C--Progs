using System;
using System.Threading.Tasks;

class TaskContinueWhenAll {
	static readonly int number = 1_000;
	static readonly int size = 100;

	static double SampleMean(Object obj) {
		Random zzg = new Random((int)obj);
		double erg = 0.0;
		for (int j = 0; j < size; j++)
			erg += zzg.NextDouble();
		return erg/size;
	}

    static void Summary(Task<double> sampleMeanTask) {
		Console.WriteLine("Mittelwert der zuerst abgeschlossenen Aufgabe: " + sampleMeanTask.Result);
	}

	static void Main() {
		var sampleMeanTaskArray = new Task<double>[number];
		for (int i = 0; i < number; i++)
			sampleMeanTaskArray[i] = Task.Factory.StartNew<double>(SampleMean, i);
		Task summaryTask = Task.Factory.ContinueWhenAny<double>(sampleMeanTaskArray, Summary);
		try {
			summaryTask.Wait();
		} catch (Exception ex) {
			Console.WriteLine(ex);
		}
	}
}