using System;
using System.Windows.Forms;

//[Flags]
//public enum AnchorStyles {
//    None = 0,
//    Top = 1,
//    Bottom = 2,
//    Left = 4,
//    Right = 8
//}

//public enum DockStyle {
//    None = 0,
//    Top = 1,
//    Bottom = 2,
//    Left = 3,
//    Right = 4,
//    Fill = 5
//}

class Prog {
	static void Main() {
		Console.WriteLine("AnchorStyles-Werte:");
		for (AnchorStyles i = 0; (int) i < 8; i++)
			Console.WriteLine(" {0}: {1}", (int) i, i);
		Console.WriteLine("\nDockStyle-Werte:");
		for (DockStyle i = 0; (int)i < 8; i++)
			Console.WriteLine(" {0}: {1}", (int)i, i);
		//Console.WriteLine("\nAnchorStyles.Top | AnchorStyles.Left\t" +
		//    (AnchorStyles.Top | AnchorStyles.Left));
		//Console.WriteLine("DockStyle.Top | DockStyle.Left\t\t" +
		//    (DockStyle.Top | DockStyle.Left));
		//Console.WriteLine((DockStyle.Top | DockStyle.Left) == DockStyle.Left);
		Console.Read();
	}
}
