using System;
class StringUtilTest {
    static void Main() {
        string s = "Dieser Satz passt nicht in eine Schmal-Zeile, " +
                   "die nur wenige Spalten umfasst.";
        StringUtil.WrapLine(s, " -", 40); Console.WriteLine();
        StringUtil.WrapLine(s, 40); Console.WriteLine();
        StringUtil.WrapLine(s); Console.WriteLine();
        StringUtil.WrapLine(s, 8);
        Console.ReadLine();
    }
}
