using System;
using System.Threading;

public class SafeDecSpin {
	decimal val;
	SpinLock sync;

	public decimal Value {
		get {
			bool hasLock = false;
			try {
				sync.Enter(ref hasLock);
				return val;
			} finally {
				if (hasLock)
					sync.Exit(false);
			}
		}
		set {
			bool hasLock = false;
			try {
				sync.Enter(ref hasLock);
				val = value;
			} finally {
				if (hasLock)
					sync.Exit(false);
			}
		}
	}
}

public class SafeDecMon {
	decimal val;
	Object sync = new object();

	public decimal Value {
		get {
			lock(sync) {
				for (int i = 0; i < 10000; i++)
					i = i * i;
				return val;
			}
		}
		set {
			lock(sync) {
				val = value;
			}
		}
	}
}

class SpinLockDemo {
    //static SafeDecSpin sd = new SafeDecSpin();
    static SafeDecMon sd = new SafeDecMon();
    const int LIMIT = 1_000_000;
	static long zeit;

	static void WriteDec() {
		for (int i = 0; i < LIMIT; i++)
			sd.Value = 1234567.99m;
		long dauer = DateTime.Now.Ticks - zeit;
		Console.WriteLine("\nBenötigte Zeit:\t" + dauer/1.0e4 + " Millisek.");
	}

	static void Main() {
		Thread w1 = new Thread(WriteDec);
		Thread w2 = new Thread(WriteDec);
		zeit = DateTime.Now.Ticks;
        zeit = DateTime.Now.Ticks;
        w1.Start();
		w2.Start();
	}
}
