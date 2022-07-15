using System;
using System.Runtime.InteropServices;

class FloatBits {
	static void Main() {
		Union uni = new Union();
		float f;
		Console.Write("float: ");
		f = Convert.ToSingle(Console.ReadLine());
		uni.f = f;
		int bits = uni.i;
		Console.WriteLine("\nBits:\n1 12345678 12345678901234567890123");
		for (int i = 31; i >= 0; i--) {
			if (i == 30 || i == 22)
				Console.Write(' ');
			if ((1 << i & bits) != 0)
				Console.Write('1');
			else
				Console.Write('0');
		}
		Console.WriteLine("\n\ngespeichert:\n"+uni.f);
		Console.ReadLine();
	}
}

[StructLayout(LayoutKind.Explicit)]
public struct Union {
	[FieldOffset(0)]
	public float f;
	[FieldOffset(0)]
	public int i;
}