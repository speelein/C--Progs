using System;
using System.IO;
using System.Text;
class BinWrtRd {
	static void Main() {
		String name = "demo.bin";
		FileStream fso = new FileStream(name, FileMode.Create);
		BinaryWriter bw = new BinaryWriter(fso);
		bw.Write(4711);
		bw.Write(3.1415926);
		bw.Write("Nicht übel");
		bw.Close();

		FileStream fsi = new FileStream(name, FileMode.Open, FileAccess.Read);
		BinaryReader br = new BinaryReader(fsi);
		Console.WriteLine(br.ReadInt32() + "\n" +
						  br.ReadDouble() + "\n" +
						  br.ReadString());
		Console.ReadLine();
	}
}
