using System;

interface IPromotion {
    void Promote();
}

class Employee : IPromotion {
    public string Name;
    public int JobGrade;

    public void Promote() {
        JobGrade++;
    }

    public Employee(string name, int jobGrade) {
        this.Name = name;
        this.JobGrade = jobGrade;
    }

    public override string ToString() {
        return string.Format("{0} ({1})", Name, JobGrade);
    }
}

class Prog {
    static void Main(string[] args)    {
        Employee employee = new Employee("Cool Guy", 65);
        IPromotion p = employee;
        Console.WriteLine(employee);
        p.Promote();
        Console.WriteLine(employee);
    }
}