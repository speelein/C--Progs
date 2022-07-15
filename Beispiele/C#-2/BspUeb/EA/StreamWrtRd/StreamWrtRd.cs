using System;
using System.IO;

class StreamWrtRd {
    static void Main() {
        const string NAME = "demo.txt";
        StreamWriter sw = new StreamWriter(NAME);
        sw.WriteLine(4711);
        sw.WriteLine(3.1415926);
        sw.WriteLine("Nicht übel");
        sw.Close();

        StreamReader sr = new StreamReader(
                          new FileStream(NAME, FileMode.Open, FileAccess.Read));
        Console.WriteLine("Inhalt der Datei " +
                          ((FileStream)sr.BaseStream).Name + "\n");
        for (int i = 0; sr.Peek() >= 0; i++ ) {
            Console.WriteLine(i + ":\t" + sr.ReadLine());
        }
        Console.ReadLine();
    }
}
