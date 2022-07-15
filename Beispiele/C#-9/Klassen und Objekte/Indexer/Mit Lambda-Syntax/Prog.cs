using System;
class Prog {
    static void Main() {
        var collection = new MyArrayList();
        collection.Add("Fist");
        Console.WriteLine(collection[0]);
        collection[0] = "Second";
        Console.WriteLine(collection[0]);
    }
}
