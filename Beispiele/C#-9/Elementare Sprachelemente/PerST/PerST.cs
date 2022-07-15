using System;
class PerST {
	static void Main(String[] args) {
		if (args.Length < 2) {
			Console.WriteLine("Bitte Lieblingsfarbe und -zahl angeben!");
			return;
		}
		String farbe = args[0].ToLower();
		int zahl = Convert.ToInt32(args[1]);
		switch (farbe) {
			case "rot":
				Console.WriteLine("Sie sind durchsetzungsfreudig und impulsiv.");
				break;
			case "schwarz":
				Console.WriteLine("Nehmen Sie nicht alles so tragisch.");
				break;
			default:
				Console.WriteLine("Ihre Emotionalität ist unauffällig.");
				if (zahl % 2 == 0)
					Console.WriteLine("Sie haben einen geradlinigen Charakter.");
				else
					Console.WriteLine("Sie machen wohl gerne krumme Touren.");
                break;
        }
	}
}
