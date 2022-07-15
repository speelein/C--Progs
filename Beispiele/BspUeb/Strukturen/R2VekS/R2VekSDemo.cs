using System;

class R2VekSDemo {
	static void Main() {
		R2VekS v1 = new R2VekS(1,0), v2 = new R2VekS(1,1);

		Console.WriteLine("Vektor 1:\t\t({0,5:f2}; {1,5:f2})",v1.X, v1.Y);
		Console.WriteLine("Vektor 2:\t\t({0,5:f2}; {1,5:f2})",v2.X, v2.Y);

		Console.WriteLine("\nLänge von Vektor 1:\t{0,5:f2}", v1.Laenge);
		Console.WriteLine("\nLänge von Vektor 2:\t{0,5:f2}", v2.Laenge);

		Console.WriteLine("\nWinkel:\t\t\t{0,5:f2} Grad", v1.Winkel(v2));

		Console.Write("\nUm wie viel Grad soll Vektor 2 gedreht werden: ");
		int winkel = Convert.ToInt32(Console.ReadLine());

		v2.Drehe(winkel);
		Console.WriteLine("\nNeuer Vektor 2\t\t({0,5:f2}; {1,5:f2})",v2.X, v2.Y);
	
		v2.Normiere();
		Console.WriteLine("Neuer Vektor 2 normiert\t({0,5:f2}; {1,5:f2})",v2.X, v2.Y);

		v1.Addiere(v2);
		Console.WriteLine("\nSumme der Vektoren\t({0,5:f2}; {1,5:f2})",v1.X, v1.Y);

        Console.WriteLine("\nBeenden mit Enter");
        Console.ReadLine();
	}
}
