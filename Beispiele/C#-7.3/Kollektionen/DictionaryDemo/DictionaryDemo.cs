using System;
using System.Collections.Generic;

class DictionaryDemo {
    public static void CountLetters(String text) {
        var fred = new Dictionary<char, int>();
        foreach (char c in text)
            if (fred.ContainsKey(c)) {
                fred[c]++;
            } else
                fred.Add(c, 1);

        foreach (KeyValuePair<char, int> kvp in fred)
            Console.WriteLine($"{kvp.Key} : {kvp.Value}");

        Console.WriteLine();
        foreach (char k in fred.Keys)
                Console.WriteLine(k);

        Console.WriteLine();
        foreach (int i in fred.Values)
            Console.WriteLine(i);
    }

    static void Main() {
        CountLetters("Otto spielt Lotto.");
    }
}
