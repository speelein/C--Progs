using System;
using System.Text;

public static class StringUtil {
    const int NCOLDEF = 72;
    const string DELIMDEF = " \t\n";

    public static void WrapLine(this string text, string delim, int ncol) {
        // Unsinnige Zeilenbreite verhindern 
        if (ncol < 1)
            ncol = 1;

        // Verlust von Bindestrichen in der Trennzeichenrolle möglichst verhindern
        int bsPos = delim.IndexOf("-");
        int leerPos = delim.IndexOf(" ");
        if (bsPos >= 0  && leerPos >= 0) {
            text = text.Replace("-", "- ");
            delim = delim.Remove(bsPos, 1);
        }

        // Ausgabe mit Umbruch
        string[] tokens = text.Split(delim.ToCharArray());
        StringBuilder zeile = new StringBuilder();
        string s;
        int i = 0;
        while (i < tokens.Length) {
            s = tokens[i];
            while (true) {
                if (zeile.Length + s.Length <= ncol + 1) {
                    zeile.Append(s);
                    zeile.Append(" ");
                    i++;
                    break;
                } else {
                    if (zeile.Length > 0) {
                        Console.WriteLine(zeile.ToString().TrimStart(null));
                        zeile.Remove(0, zeile.Length);
                    } else {
                        Console.WriteLine(s.Substring(0,ncol));
                        s = s.Substring(ncol, s.Length - ncol);
                    }
                }
            }
        }
        Console.WriteLine(zeile.ToString().TrimStart(null));
    }

    public static void WrapLine(this string text, int ncol) {
        WrapLine(text, DELIMDEF, ncol);
    }

    public static void WrapLine(this String text) {
        WrapLine(text, DELIMDEF, NCOLDEF);
    }
}
