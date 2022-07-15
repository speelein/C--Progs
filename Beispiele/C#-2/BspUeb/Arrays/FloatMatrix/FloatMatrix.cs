using System;

public class FloatMatrix {
	public float[,] Data;
	int z, s;
	
	public FloatMatrix(int z_, int s_) {
		Data = new float[z_,s_];
		z = z_;
		s = s_;
	}

	public int Zeilen {
		get {
			return z;
		}
	}

	public int Spalten {
		get {
			return s;
		}
	}

	public void Anzeigen() {
		for (int i = 0; i < z; i++) {
			for (int j = 0; j < s; j++)
				Console.Write("{0,7:f2}",Data[i,j]);
			Console.WriteLine();
			}
		Console.WriteLine();
	}

	public void Transponieren() {
		if (z == s) {
			float puffer;
			for (int i=0; i < z; i++)
				for(int j= 0; j < i; j++) {
					puffer = Data[i,j];
					Data[i,j] = Data[j,i];
					Data[j,i] = puffer;
				}
		} else {
			int temp = z;
			z = s;
			s = temp;
			float[,] nData = new float[z,s];
			for (int i = 0; i < z; i++)
				for(int j = 0; j < s; j++)
					nData[i,j] = Data[j,i];
			Data = nData;
		}
	}
}
