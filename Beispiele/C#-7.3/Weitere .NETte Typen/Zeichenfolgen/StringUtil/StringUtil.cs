using System;
using System.Text;

public static class StringUtil {
    const int NCOLDEF = 72;

    public static void WrapLine(String text, int ncol = NCOLDEF, bool hypSep = false) {
        // Unsinnige Zeilenbreite verhindern 
        if (ncol < 1)
            ncol = 1;
        // Ein Bindestrich zwischen 2 Nicht-Leerzeichen wird als optionaler Trennstrich markiert.
        if (hypSep)
            for (int j = 1; j < text.Length - 2; j++)
                if (text[j] == '-' && text[j-1] != ' ' && text[j+1] != ' ')
                    text = text.Insert(j+1, "{opt} ");

        String[] tokens = text.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder zeile = new StringBuilder();
        String s;
        int i = 0;
        bool optSep;
        while (i < tokens.Length) {
            optSep = false;
            s = tokens[i];
            // Optionalen Trennstrich erkennen und Markierung entfernen.
            if (s.Length >= 5 && s.Substring(s.Length - 5) == "{opt}") {
                optSep = true;
                s = s.Substring(0, s.Length - 5);
            }
            while (true) {
                if (zeile.Length + s.Length <= ncol) {
                    zeile.Append(s);
                    if (zeile.Length < ncol && !optSep)
                        zeile.Append(" ");
                    i++;
                    break;
                } else {
                    if (zeile.Length > 0) {
                        Console.WriteLine(zeile.ToString());
                        zeile.Remove(0, zeile.Length);
                    } else {
                        Console.WriteLine(s.Substring(0, ncol));
                        s = s.Substring(ncol, s.Length - ncol);
                    }
                }
            }
        }
        Console.WriteLine(zeile.ToString());
    }
}
