using System;
class Prog {
	static void Main() {
		EinfachStapel<double> ds = new EinfachStapel<double>(10);
		ds.Auflegen(3.141); ds.Auflegen(2.718);
		try {
			for (int i = 1; i <= 3; i++)
				Console.WriteLine("Oben lag: " + ds.Abheben());
		} catch (Exception e) {
			Console.WriteLine("\n *** Ausnahmefehler: "+e.Message);
		}
		Console.Read();
	}
}
