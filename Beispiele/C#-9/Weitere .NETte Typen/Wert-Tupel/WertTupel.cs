using System;
using System.Text;

class WertTupel {
    static (string First, string Last, bool FirstPalin, bool LastPalin) AnalyzeName(string name) {
    //static (string, string, bool, bool) AnalyzeName(string name) {
        int posSpace = name.IndexOf(" ");
        int lenLast = name.Length - (posSpace + 1);
        string fn = name.Substring(0, posSpace);
        string ln = name.Substring(posSpace + 1, lenLast);
        bool CheckPalin(string ins) {
            int len = ins.Length;
            var sb = new StringBuilder(len);
            for (int i = 0; i < len; i++)
                sb.Append(ins[len - i - 1]);
            return sb.ToString().ToUpper() == ins.ToUpper();
        }
        return (fn, ln, CheckPalin(fn), CheckPalin(ln));
    }

    static void Main() {
        var an = AnalyzeName("Otto Rentner");
        Console.WriteLine(an.First);
        //Console.WriteLine(an.Item1);
        var (first, last, firstPal, lastPal) = AnalyzeName("Otto Rentner");
        Console.WriteLine(firstPal);
        //Console.WriteLine(AnalyzeName("Otto Rentner").Item3);
    }
}
