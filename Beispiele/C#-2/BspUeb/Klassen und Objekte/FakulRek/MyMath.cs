// rekursive Berechnung der Fakult�t

public class MyMath {
	public static double Fakul(int arg) {
		if (arg == 1)
			return 1;
		else
			return arg * Fakul(arg-1);
	}	
}
