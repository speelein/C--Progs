using System;

public class EinfachStapel<T> {
	int maxHoehe = 5;
	T[] daten;
	int aktHoehe;

	public EinfachStapel() {
		daten = new T[maxHoehe];
	}
	public EinfachStapel(int max) {
		if (max > 0) {
			maxHoehe = max;
			daten = new T[maxHoehe];
		} else
			throw new InvalidOperationException("Aktualparameterwert max unzulässig");
	}

	public void Auflegen(T element) {
		if (aktHoehe < maxHoehe) {
			daten[aktHoehe++] = element;
		} else
			throw new InvalidOperationException("Maximale Stapelhöhe erreicht");
	}

	public T Abheben() {
		if (aktHoehe > 0)
			return daten[--aktHoehe];
		else
			throw new InvalidOperationException("Kein Element vorhanden");
	}
}
