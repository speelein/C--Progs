using System;
class Prog {
	static void Main() {
		K k = new K();
		I1 i1 = k;
		I2 i2 = k;
		Console.WriteLine(i1.M());
		Console.WriteLine(i2.M());
		//Console.WriteLine(k.M());
	}
}
