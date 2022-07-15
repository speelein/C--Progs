using System;
using System.Threading;
using System.Threading.Tasks;

public sealed class HarmlessException : Exception {
	public HarmlessException(String message) : base(message) {}
}

public sealed class SeriousException : Exception {
	public SeriousException(String message)	: base(message) {}
}

class WaitDemo {
	static void Werfer() {
		throw new HarmlessException("Harmlos");
		//throw new SeriousException("Ernstfall");
	}

	static bool InternalExceptionHandler(Exception e) {
		if (e is HarmlessException) {
			Console.WriteLine(e.Message);
			return true;
		} else
			return false;
	}

	static void Main() {
		Task t = Task.Factory.StartNew(Werfer);
		try {
			t.Wait();
		} catch (AggregateException ae) {
			ae.Handle(InternalExceptionHandler);
		}

		Console.WriteLine("Normales Ende");
		Console.ReadLine();
	}
}