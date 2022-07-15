using System;
using System.Threading.Tasks;

class TaskDemo {
	const int N = 10_000_000;

    static void SampleMean() {
        var zzg = new Random();
        double erg = 0.0;
        for (int j = 0; j < N; j++)
            erg += zzg.NextDouble();
        Console.WriteLine("Stichprobenmittel " + (erg / N));
        //Console.WriteLine("Stichprobenmittel " + (erg/SG) + " berechnet von Thread " +
        //					Thread.CurrentThread.ManagedThreadId);
    }


    static void Main() {
        //var task = new Task(SampleMean);
        //task.Start();

        //Task task = Task.Factory.StartNew(SampleMean);

        //Task task = Task.Run(new Action(SampleMean));
        //Task task = Task.Run(()=>SampleMean());
        Task task = Task.Run((Action)SampleMean);
        task.Wait();
    }
}