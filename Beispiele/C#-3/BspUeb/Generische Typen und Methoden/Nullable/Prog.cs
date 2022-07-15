using System;
class Prog {
	static void Main() {
		EinfachStapel<double?> ds = new EinfachStapel<double?>(3);
		double? d;
		ds.Auflegen(3.141); ds.Auflegen(2.718);
		for (int i = 1; i <= 3; i++) {
			d = ds.Abheben();
			if (d != null)
				Console.WriteLine("Oben lag: " + d);
			else
				Console.WriteLine("Stapel war leer." +
					"\n d.HasValue = " + d.HasValue);
		}
		Console.Read();
	}
}
