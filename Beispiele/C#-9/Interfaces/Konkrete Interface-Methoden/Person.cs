using System;

interface IPerson {
    string Name { get; }
    DateTime BirthDay { get; }
    const int allowedBirthDayDelay = 10;
    private static int maxBirthDayDelay = allowedBirthDayDelay;

    static int MaxBirthDayDelay {
        get { return maxBirthDayDelay; }
        set {
            if (value <= allowedBirthDayDelay)
                maxBirthDayDelay = value;
        }
    }

    void SendBirthDayGreetings() {
        DateTime birthDayThisYear = new DateTime(DateTime.Today.Year, BirthDay.Month, BirthDay.Day);
        DateTime birthDayLastYear = new DateTime(DateTime.Today.Year-1, BirthDay.Month, BirthDay.Day);

        double elapsedDays;
        if (DateTime.Today < birthDayThisYear)
            elapsedDays = (DateTime.Today - birthDayLastYear).TotalDays;
        else
            elapsedDays = (DateTime.Today - birthDayThisYear).TotalDays;

        if (elapsedDays >= 0 && elapsedDays <= maxBirthDayDelay)
            Console.WriteLine($"Liebe*r {Name}, herzlichen Glückwunsch zum Geburtstag!");
    }
}

class Person : IPerson {
    public string Name { get; private set;}
    public DateTime BirthDay { get; private set; }

    static void Main() {
        Person p = new Person() { Name = "Franz", BirthDay = new DateTime(1988, 12, 22) };
        IPerson.MaxBirthDayDelay = 8;
        IPerson iface = p;
        iface.SendBirthDayGreetings();
    }
}