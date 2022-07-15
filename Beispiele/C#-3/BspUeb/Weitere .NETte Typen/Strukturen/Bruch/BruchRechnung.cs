using System;
class BruchRechnung {
	static void Main() {
		Bruch b1 = new Bruch(1,2,"b1 =");
		Bruch b2 = new Bruch();
		b1.Zeige();
		b2.Zeige();

		//long zeit = DateTime.Now.Ticks;
		//Bruch[] ba = new Bruch[1000000];
		//for (int i = 0; i < 1000000; i++) {
		//    ba[i] = new Bruch();
		//}
		//zeit = DateTime.Now.Ticks - zeit;
		//Console.WriteLine("\nBenöt. Zeit:\t" + zeit / 1.0e4 + " Millisek.");
        Console.ReadLine();
	}
}
