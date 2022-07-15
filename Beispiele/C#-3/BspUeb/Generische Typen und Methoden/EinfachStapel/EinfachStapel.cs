using System;
public class EinfachStapel<T> {
	int maxHoehe = 5;
	T[] daten;
	int aktHoehe;

	public EinfachStapel() {
		daten = new T[maxHoehe];
	}
	public EinfachStapel(int max) {
		maxHoehe = max;
		daten = new T[maxHoehe];
	}

	public bool Auflegen(T element) {
		if (aktHoehe < maxHoehe) {
			daten[aktHoehe++] = element;
			return true;
		} else
			return false;
	}

	public bool Abheben(out T element) {
		if (aktHoehe > 0) {
			element = daten[--aktHoehe];
			return true;
		} else {
			element = default(T);
			return false;
		}
	}
}
