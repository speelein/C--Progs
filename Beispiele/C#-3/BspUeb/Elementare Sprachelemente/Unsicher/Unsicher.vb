Option Explicit Off

Module Module1
    Sub Main()
        ' Fehler durch Abschalten des Deklarationszwangs
        ii = 12  ' Verwendung ohne Deklaration
        ij = ii + 1  ' Tippfehler fällt nicht auf
        Console.WriteLine(ii.GetType().FullName)
        Console.WriteLine(ii)
        Console.WriteLine()

        ' Fehler durch dynamische Typänderung
        di = 0.0
        ii = 3.14 ' Tippfehler fällt nicht auf
        Console.WriteLine(ii.GetType().FullName)
        Console.WriteLine(di)
        Console.WriteLine(ii)
        Console.ReadLine()
    End Sub
End Module
