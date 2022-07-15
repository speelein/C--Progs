// rekursive Berechnung der Fakultät

public class MyMath {
	public static double Fakul(int arg) {
		if (arg == 0 || arg == 1)
			return 1;
		else
			if (arg == 2)
				return 2;
			else
				if (arg > 2 && arg <= 170)
					return arg * Fakul(arg - 1);
				else
					return double.NaN;
	}	
}
