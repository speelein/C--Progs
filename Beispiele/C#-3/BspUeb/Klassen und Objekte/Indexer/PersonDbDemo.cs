using System;
class PersonDbDemo {
	static void Main() {
		PersonDB adb = new PersonDB();
		adb.Add(new Person("Otto", "Kolbe"));
		adb.Add(new Person("Kurt", "Saar"));
		adb.Add(new Person("Theo", "Müller"));
		for (int i = 0; i < adb.Count; i++)
			Console.WriteLine("Nummer {0}: {1} {2}", i, adb[i].Vorname, adb[i].Name);
		Console.WriteLine();
		adb[1] = new Person("Ilse", "Golter");
		for (int i = 0; i < adb.Count; i++)
			Console.WriteLine("Nummer {0}: {1} {2}", i, adb[i].Vorname, adb[i].Name);
		Console.ReadLine();
	}
}