using System;
class FloatMatrixDemo {
	static void Main() {
		const int zeilen = 3, spalten = 5;
		var matrix = new FloatMatrix(zeilen, spalten);

		for (int i = 0; i < zeilen; i++)
			for (int j = 0; j < spalten; j++)
				matrix[i,j] = i * spalten + j + 1;

        Console.WriteLine("Die Originalmatrix hat " + matrix.Zeilen + " Zeilen und " + matrix.Spalten + " Spalten:\n");
        matrix.Anzeigen();
        matrix.Transponieren();
        Console.WriteLine("Die transponierte Matrix hat " + matrix.Zeilen + " Zeilen und " + matrix.Spalten + " Spalten:\n");
        matrix.Anzeigen();
        Console.ReadLine();
	}
}