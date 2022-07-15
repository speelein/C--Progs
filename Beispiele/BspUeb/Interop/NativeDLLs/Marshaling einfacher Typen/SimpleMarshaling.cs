using System;
using System.Text;
using System.Runtime.InteropServices;
class SimpleMarshaling {
	[DllImport("kernel32.dll")]
	static extern int GetWindowsDirectory(StringBuilder sb,	int maxChars);
	static void Main() {
		StringBuilder s = new StringBuilder(256);
		GetWindowsDirectory(s, 256);
		Console.WriteLine(s); Console.ReadLine();
	}
}
