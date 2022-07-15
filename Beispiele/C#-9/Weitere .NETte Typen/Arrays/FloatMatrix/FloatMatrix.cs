using System;

public class FloatMatrix {
	float[,] Data;
    const int maxSize = 2_621_440; // Die Array-Größe wird beschränkt auf 10 MB.

    public FloatMatrix(int z_, int s_) {
        if (z_ > 0  &&  s_ > 0  &&  z_*s_ <= maxSize) {
            Data = new float[z_, s_];
            Zeilen = z_;
            Spalten = s_;
        }
	}

    public int Zeilen { get; private set; }

    public int Spalten { get; private set; }

    public float this[int z, int s] {
        get {
            return Data[z, s];
        }
        set {
            Data[z, s] = value;
        }
    }

    public void Anzeigen() {
		for (int i = 0; i < Zeilen; i++) {
			for (int j = 0; j < Spalten; j++)
				Console.Write("{0,7:f2}", Data[i,j]);
			Console.WriteLine();
			}
		Console.WriteLine();
	}

	public void Transponieren() {
		if (Zeilen == Spalten) {
			float puffer;
			for (int i=0; i < Zeilen; i++)
				for(int j= 0; j < i; j++) {
					puffer = Data[i,j];
					Data[i,j] = Data[j,i];
					Data[j,i] = puffer;
				}
		} else {
			int temp = Zeilen;
			Zeilen = Spalten;
			Spalten = temp;
			float[,] nData = new float[Zeilen,Spalten];
			for (int i = 0; i < Zeilen; i++)
				for(int j = 0; j < Spalten; j++)
					nData[i,j] = Data[j,i];
			Data = nData;
		}
	}
}
