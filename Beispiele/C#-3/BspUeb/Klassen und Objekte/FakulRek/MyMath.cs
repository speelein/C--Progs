// rekursive Berechnung der Fakultät

public class MyMath {
	public static double Fakul(int arg) {
		if (arg == 2)
			return 2;
		else
			return arg * Fakul(arg-1);
	}	
}
