using System;
class PersonDbDemo {
    static void Main() {
        PersonDB adb = new PersonDB("Otto", "Kolbe");
        adb.Add("Kurt", "Saar");
        adb.Add("Theo", "Müller");
        for (int i = 0; i < adb.N; i++)
            Console.WriteLine("Nummer {0}: {1} {2}",
                             i, adb[i].Vorname, adb[i].Name);
        adb[1] = new Person("Ilse", "Golter");
        Console.WriteLine();
        for (int i = 0; i < adb.N; i++)
            Console.WriteLine("Nummer {0}: {1} {2}",
                             i, adb[i].Vorname, adb[i].Name);
        Console.ReadLine();
    }
}
