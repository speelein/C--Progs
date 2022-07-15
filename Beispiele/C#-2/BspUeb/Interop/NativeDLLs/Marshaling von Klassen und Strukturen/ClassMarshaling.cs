using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
class SystemTime {
	public ushort wYear = 0;
	public ushort wMonth = 0;
	public ushort wDayOfWeek = 0;
	public ushort wDay = 0;
	public ushort wHour = 0;
	public ushort wMinute = 0;
	public ushort wSecond = 0;
	public ushort wMilliseconds = 0;
}

class ClassMarshaling {
	[DllImport("kernel32.dll")]
	static extern void GetSystemTime(SystemTime t);

	static void Main() {
		SystemTime t = new SystemTime();
		GetSystemTime(t);
		Console.WriteLine("Datum: " + t.wDay + "." + t.wMonth + "." + t.wYear);
		Console.ReadLine();
	}
}
