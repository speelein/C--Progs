using System;
class Person : IComparable<Person> {
	public string Vorname;
	public string Name;
	public Person(string vorname, string nachname) {
		Vorname = vorname;
		Name = nachname;
	}
	public int CompareTo(Person p) {
		int vergl = (this.Name+this.Vorname).CompareTo(p.Name+p.Vorname);
		if (vergl < 0)
			return -1;
		else
			if (vergl == 0)
				return 0;
			else
				return 1;
	}
}