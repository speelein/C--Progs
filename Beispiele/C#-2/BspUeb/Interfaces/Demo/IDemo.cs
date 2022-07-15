using System;

interface IDemo {
    int SagWas();
}

class Kid1 : IDemo {
    public int SagWas() {return 1;}
}

class Kid2 : IDemo {
    public int SagWas() {return 2;}
}

class Prog {
    static void Main() {
        IDemo o1 = new Kid1(),
              o2 = new Kid2();
        Console.WriteLine("Kid1-Objekt: "+o1.SagWas());
        Console.WriteLine("Kid2-Objekt: "+o2.SagWas());
        Console.ReadLine();
    }
}
