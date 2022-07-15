using System;

enum Temperament {cholerisch, melancholisch, sanguin, phlegmatisch};

class Person {
	public string Vorname;
	public string Name;
	public int  Alter;
	public Temperament Temp;

	public Person(string vor, string nach, int alt, Temperament tp) {
		Vorname = vor;
		Name = nach;
		Alter = alt;
		Temp = tp;
	}

	static void Main(){
		Person otto = new Person("Otto", "Hummer", 35, Temperament.sanguin);
		if (otto.Temp == Temperament.sanguin)
			Console.WriteLine("Lustiger Typ!");
		// wird nicht verhindert:
		otto.Temp = (Temperament) 13;
		Console.WriteLine(otto.Temp);
	}
}
