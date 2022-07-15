using System;
using System.Runtime.InteropServices;
class DoubleBits {
    static void Main() {
        Union uni = new Union();
        double d;
        Console.Write("double: ");
        d = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("\nBits: ");
        uni.d = d;
        long bits = uni.i;
        Console.WriteLine("1 12345678901 1234567890123456789012345678901234567890123456789012");
        for (int i = 63; i >= 0; i--) {
            if (i == 62 || i == 51)
                Console.Write(' ');
            if ((1L << i & bits) != 0)
                Console.Write('1');
            else
                Console.Write('0');
        }
        Console.WriteLine("\n\ngespeichert:\n"+uni.d);
        Console.ReadLine();
    }
}

[StructLayout(LayoutKind.Explicit)]
public struct Union {
    [FieldOffset(0)]
	public double d;
    [FieldOffset(0)]
	public long i;
}