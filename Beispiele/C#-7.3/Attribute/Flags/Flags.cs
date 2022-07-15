using System;
using System.Windows;
using System.Windows.Input;

class Flags	{
	static void Main() {
		Console.WriteLine("ModifierKeys-Werte:");
		for (ModifierKeys i = 0; (int)i <= 8; i++)
			Console.WriteLine(" {0}: {1}", (int)i, i);
		Console.WriteLine("\nHorizontalAlignment-Werte:");
		for (HorizontalAlignment i = 0; (int)i <= 8; i++)
			Console.WriteLine(" {0}: {1}", (int)i, i);
	}
}
