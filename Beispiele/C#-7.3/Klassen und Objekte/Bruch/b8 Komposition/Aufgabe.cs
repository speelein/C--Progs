using System;

public class Aufgabe {
	Bruch b1, b2, lsg, antwort;
	char op;

	public Aufgabe(char op_, int b1Z, int b1N, int b2Z, int b2N) {
		op = op_;
		b1 = new Bruch(b1Z, b1N, "1. Argument:");
		b2 = new Bruch(b2Z, b2N, "2. Argument:");
		lsg = new Bruch(b1Z, b1N, "Das korrekte Ergebnis:");
		antwort = new Bruch();
		Init();
	}

	private void Init() {
		switch (op) {
			case '+':	lsg.Addiere(b2);
						break;
			case '*':	lsg.Multipliziere(b2);
						break;
		}
	}

	public bool Korrekt {
		get {
            Bruch temp = antwort.Klone();
            temp.Kuerze();
            if (lsg.Zaehler == temp.Zaehler && lsg.Nenner == temp.Nenner)
                return true;
            else
                return false;
		}
	}

	public void Zeige(int was) {
		switch (was) {
			case 1:	Console.WriteLine("   " + b1.Zaehler +
						"                " + b2.Zaehler);
						Console.WriteLine(" ------     " + op + "     -----");
						Console.WriteLine("   " + b1.Nenner +
						"                " + b2.Nenner);
						break;
			case 2: lsg.Zeige(); break;
			case 3: antwort.Zeige(); break;
		}
	}

	public bool Frage() {
        try {
            Console.WriteLine("\nBerechne bitte:\n");
		    Zeige(1);
		    Console.Write("\nWelchen Zähler hat Dein Ergebnis:      ");
		    antwort.Zaehler = Convert.ToInt32(Console.ReadLine());
		    Console.WriteLine("                                     ------");
		    Console.Write("Welchen Nenner hat Dein Ergebnis:      ");
		    antwort.Nenner = Convert.ToInt32(Console.ReadLine());
            return true;
        } catch {
            return false;
        }
	}

	public void Pruefe() {
		Frage();
		if (Korrekt)
			Console.WriteLine("\n Gut!");
		else {
			Console.WriteLine();
			Zeige(2);
		}
	}

	public void NeueWerte(char op_, int b1Z, int b1N, int b2Z, int b2N) {
		op = op_;
		b1.Zaehler = b1Z; b1.Nenner = b1N;
		b2.Zaehler = b2Z; b2.Nenner = b2N;
		lsg.Zaehler = b1Z; lsg.Nenner = b1N;
		Init();
	}
}
