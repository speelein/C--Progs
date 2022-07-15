using System;
using System.Collections.Generic;
class HashSetDemo {
    static void Main() {
        var m1 = new HashSet<char> { 'a', 'b', 'c' };
        Console.WriteLine("Menge 1:");
        foreach (char c in m1) Console.Write(c + " ");

        m1.Add('b');
        Console.WriteLine("\n\nMenge 1 nach 2. b-Aufn.:");
        foreach (char c in m1) Console.Write(c + " ");

        var m2 = new HashSet<char>() { 'c', 'd', 'e' };
        Console.WriteLine("\n\nMenge 2:");
        foreach (char c in m2) Console.Write(c + " ");

        Console.WriteLine("\n\nb in der Menge 2? " + m2.Contains('b'));

        var schnitt = new HashSet<char>(m1);
        schnitt.IntersectWith(m2);
        Console.WriteLine("\nSchnittmenge:");
        foreach (char c in schnitt) Console.Write(c + " ");

        var vereinigung = new HashSet<char>(m1);
        vereinigung.UnionWith(m2);
        Console.WriteLine("\n\nVereinigungsmenge:");
        foreach (char c in vereinigung) Console.Write(c + " ");

        var differenz = new HashSet<char>(m1);
        differenz.ExceptWith(m2);
        Console.WriteLine("\n\nDifferenzmenge:");
        foreach (char c in differenz) Console.Write(c + " ");

        m1.Remove('a');
        Console.WriteLine("\n\nMenge 1 ohne a:");
        foreach (char c in m1) Console.Write(c + " ");

        m1.Clear();
        Console.WriteLine("\n\nMenge 1 nach Clear:");
        foreach (char c in m1) Console.Write(c + " ");
    }
}
