using System;
class StringUtilTest {
    static void Main() {
        string s = "Dieser Satz passt nicht in eine Schmal-Zeile, " +
                   "die nur wenige Spalten umfasst.";
		s.WrapLine(" -", 40); Console.WriteLine();
		s.WrapLine(40); Console.WriteLine();
		s.WrapLine(); Console.WriteLine();
		s.WrapLine(" -", 8); Console.WriteLine();
		s.WrapLine(s, 8);
		Console.ReadLine();
    }
}
