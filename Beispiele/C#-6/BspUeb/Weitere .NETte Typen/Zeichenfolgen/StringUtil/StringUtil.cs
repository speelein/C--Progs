using System;
using System.Text;

public static class StringUtil {
    const int NCOLDEF = 72;
    const String DELIMDEF = " \t\n";

    public static void WrapLine(String text, String delim, int ncol) {
        // Unsinnige Zeilenbreite verhindern 
        if (ncol < 1)
            ncol = 1;

		// Leerzeichen nötigenfalls als Trennzeichen ergänzen
		if (delim.IndexOf(" ") < 0)
			delim = delim.Insert(0, " ");

        // Ausgabe mit Umbruch, leere Tokens entfernen
		String[] tokens = text.Split(delim.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        StringBuilder zeile = new StringBuilder();
        String s;
        int i = 0;
        while (i < tokens.Length) {
            s = tokens[i];
            while (true) {
                if (zeile.Length + s.Length <= ncol) {
                    zeile.Append(s);
					if (zeile.Length < ncol)
						zeile.Append(" ");
                    i++;
					break;
                } else {
                    if (zeile.Length > 0) {
                        Console.WriteLine(zeile.ToString());
                        zeile.Remove(0, zeile.Length);
                    } else {
                        Console.WriteLine(s.Substring(0,ncol));
                        s = s.Substring(ncol, s.Length - ncol);
                    }
                }
            }
        }
        Console.WriteLine(zeile.ToString());
    }

    public static void WrapLine(String text, int ncol) {
        WrapLine(text, DELIMDEF, ncol);
    }

    public static void WrapLine(String text) {
        WrapLine(text, DELIMDEF, NCOLDEF);
    }
}
