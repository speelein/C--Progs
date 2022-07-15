using System.Threading;
public class Prog {
	static void Main() {
		Runner runner = new Runner();
		Thread kt = new Thread(runner.Run);
		kt.Start();
		Thread.Sleep(5000);
		//kt.Abort();
		runner.Stopped = true;
	}
}