public enum Temperament { Cholerisch, Melancholisch, Sanguin, Phlegmatisch }

public class Person {
	public string Vorname;
	public string Name;
	public int Alter;
	//public Temperament Temp;
	Temperament temp;

	public Temperament Temp {
		get {
			return temp;
		}
		set {
			if (System.Enum.IsDefined(typeof(Temperament), value))
				temp = value;
		}
	}

	public Person(string vorname, string name, int alter, Temperament temp) {
		Vorname = vorname; Name = name;	Alter = alter;
		Temp = temp;
	}
}
