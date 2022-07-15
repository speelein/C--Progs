using System;
class PersonDbDemo {
	static void Main() {
		PersonDB pdb = new PersonDB();
		pdb.Add(new Person("Otto", "Kolbe"));
		pdb.Add(new Person("Kurt", "Saar"));
		pdb.Add(new Person("Theo", "Müller"));
		for (int i = 0; i < pdb.Count; i++)
			Console.WriteLine($"Nummer {i}: {pdb[i].Vorname} {pdb[i].Name}");
		Console.WriteLine();
		pdb[1] = new Person("Ilse", "Golter");
		for (int i = 0; i < pdb.Count; i++)
			Console.WriteLine($"Nummer {i}: {pdb[i].Vorname} {pdb[i].Name}");

        String s = "Ilse";
        Console.WriteLine($"\nName der ersten Person mit dem Vornamen \"{s}\": {pdb[s].Name}");
	}
}