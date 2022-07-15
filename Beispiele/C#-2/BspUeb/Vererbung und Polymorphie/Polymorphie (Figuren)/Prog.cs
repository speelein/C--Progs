using System;
class Vater {
    int iva = 3;
    public Vater(int iva_) { iva = iva_; }
//    public Vater() { }
    public virtual void Hallo() { Console.WriteLine("Hallo-Methode des Vaters"); }
}
class Sohn : Vater {
    override public void Hallo() { Console.WriteLine("Hallo-Methode des Sohnes"); }
}
class Prog {
    static void Main() {
        Sohn s = new Sohn();
        s.Hallo();
        Console.ReadLine();
    }
}
