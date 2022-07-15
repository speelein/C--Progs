using System;
class FloatMatrixDemo {
	static void Main() {
		const int ZEILEN = 3, SPALTEN = 5;
		var matrix = new FloatMatrix(ZEILEN, SPALTEN);

		for (int i = 0; i < ZEILEN; i++)
			for (int j = 0; j < SPALTEN; j++)
				matrix[i,j] = i*SPALTEN + j + 1;

        Console.WriteLine("Die Originalmatrix hat " + matrix.Zeilen + " Zeilen und " + matrix.Spalten + " Spalten:\n");
        matrix.Anzeigen();
        matrix.Transponieren();
        Console.WriteLine("Die transponierte Matrix hat " + matrix.Zeilen + " Zeilen und " + matrix.Spalten + " Spalten:\n");
        matrix.Anzeigen();
        Console.ReadLine();
	}
}