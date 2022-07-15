using System;
class FloatMatrixDemo {
	static void Main() {
		const int zeilen = 3, spalten = 5;
		FloatMatrix matrix = new FloatMatrix(zeilen,spalten);

		for (int i = 0; i < zeilen; i++)
			for (int j = 0; j < spalten; j++)
				matrix.Data[i,j] = i*spalten + j + 1;

		Console.WriteLine("Die Matrix hat " + matrix.Zeilen + " Zeilen und " + matrix.Spalten + " Spalten.\n");
		Console.WriteLine("Original:\n");
		matrix.Anzeigen();
		matrix.Transponieren();
		Console.WriteLine("Transponiert:\n");
		matrix.Anzeigen();
		Console.WriteLine("Die Matrix hat " + matrix.Zeilen + " Zeilen und " + matrix.Spalten + " Spalten.\n");
        Console.ReadLine();
	}
}