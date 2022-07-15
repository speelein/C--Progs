class PersonTest {
	static void Main() {
		Person otto = new Person("Otto", "Hummer", 35, Temperament.Sanguin);
		if (otto.Temp == Temperament.Sanguin)
			System.Console.WriteLine("Lustiger Typ!");

		otto.Temp = (Temperament) 13;
		System.Console.WriteLine(otto.Temp);
	}
}