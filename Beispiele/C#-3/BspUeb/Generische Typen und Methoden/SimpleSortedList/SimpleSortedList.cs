using System;
class SimpleSortedList<T> where T : IComparable<T> {
	T[] elements;
	int firstFree;
	
	public SimpleSortedList(int len) {
		if (len > 0)
			elements = new T[len];
	}
	
	public void Add(T element) {
		if (firstFree == elements.Length)
			return;
		bool inserted = false;
		for (int i = 0; i < firstFree; i++) {
			if (element.CompareTo(elements[i]) <= 0) {
				for (int j = firstFree; j > i; j--)
					elements[j] = elements[j-1];
				elements[i] = element;
				inserted = true;
				break;
			}
		}
		if (!inserted)
			elements[firstFree] = element;
		firstFree++;
	}

	public bool Get(int index, out T value) {
		if (index >= 0 && index < firstFree) {
			value = elements[index];
			return true;
		} else {
			value = default(T);
			return false;
		}
	}
}