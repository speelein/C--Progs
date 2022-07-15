using System;
using System.Threading.Tasks;

class TaskDemo {
	const int SG = 10000000;
	static void SampleMean() {
		Random zzg = new Random();
		double erg = 0.0;
		for (int j = 0; j < SG; j++)
			erg += zzg.NextDouble();
		Console.WriteLine("Stichprobenmittel " + (erg / SG));
		//Console.WriteLine("Stichprobenmittel " + (erg/SG) + " berechnet von Thread " +
		//					Thread.CurrentThread.ManagedThreadId);
	}

	static void Main() {
		//Task task = new Task(SampleMean);
		//task.Start();

		//Task task = Task.Factory.StartNew(SampleMean);
		//Task.Run(new Action(SampleMean));
		//Task.Run(()=>SampleMean());
		Task task = Task.Run((Action)SampleMean);
		task.Wait();
	}
}