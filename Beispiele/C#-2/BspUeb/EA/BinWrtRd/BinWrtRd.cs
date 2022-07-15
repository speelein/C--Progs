using System;
using System.IO;
class BinWrtRd {
    static void Main() {
        const String NAME = "demo.bin";
        FileStream fso = new FileStream(NAME, FileMode.Create);
        BinaryWriter bw = new BinaryWriter(fso);
        bw.Write(4711);
        bw.Write(3.1415926);
        bw.Write("Nicht übel");
        bw.Close();

        FileStream fsi = new FileStream(NAME, FileMode.Open, FileAccess.Read);
        BinaryReader br = new BinaryReader(fsi);
        Console.WriteLine(br.ReadInt32() + "\n" +
                          br.ReadDouble() + "\n" +
                          br.ReadString());
        Console.ReadLine();
    }
}
