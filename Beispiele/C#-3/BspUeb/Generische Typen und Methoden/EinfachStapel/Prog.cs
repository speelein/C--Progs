using System;
class Prog {
	static void Main() {
		EinfachStapel<double> ds = new EinfachStapel<double>(10);
		ds.Auflegen(3.141); ds.Auflegen(2.718);
		double d;
		for (int i = 1; i <= 3; i++)
			if (ds.Abheben(out d))
				Console.WriteLine("Oben lag: " + d);
			else
				Console.WriteLine("Stapel war leer");
		Console.ReadLine();
	}
}
