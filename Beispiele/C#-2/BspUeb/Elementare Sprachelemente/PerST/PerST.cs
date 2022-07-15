using System;
class PerST {
    static void Main(string[] args) {
        if (args.Length < 2) {
            Console.WriteLine("Bitte Lieblingsfarbe und -zahl angeben!");
            return;
        }
        char farbe = args[0][0];
        int zahl = Convert.ToInt32(args[1]);
        switch (farbe) {
            case 'r':
                Console.WriteLine("Sie sind ein emotionaler Typ.");
                break;
            case 'g':
            case 'b': {
                    Console.WriteLine("Sie scheinen ein sachlicher Typ zu sein");
                    if (zahl % 2 == 0)
                        Console.WriteLine("Sie haben einen geradlinigen Charakter.");
                    else
                        Console.WriteLine("Sie machen wohl gerne krumme Touren.");
                }
                break;
            case 's':
                Console.WriteLine("Nehmen Sie nicht Alles so tragisch.");
                break;
            default:
                Console.WriteLine("Offenbar mangelt es Ihnen an Disziplin.");
                break;
        }
        Console.ReadLine();
    }
}
