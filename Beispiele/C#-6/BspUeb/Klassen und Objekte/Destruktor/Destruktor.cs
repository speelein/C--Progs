using System;

class K1 {
	~K1() {
		Console.WriteLine("K1-Destruktor");
	}
}

class K2 : K1 {
	~K2() {
		Console.WriteLine("K2-Destruktor");
	}
}

class KD {
	static void Main() {
		K2 k2 = new K2();
	}
}
