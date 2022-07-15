public class SimpleSortedList<T> where T : System.IComparable<T> {
	int capacity = 5;
	T[] data;
	int size;

	public SimpleSortedList() {
		data = new T[capacity];
	}
	public SimpleSortedList(int len) {
		if (len > 0)
			capacity = len;
		data = new T[capacity];
	}

	public bool Add(T element) {
		if (size == data.Length)
			return false;
		bool inserted = false;
		for (int i = 0; i < size; i++) {
			if (element.CompareTo(data[i]) <= 0) {
				for (int j = size; j > i; j--)
					data[j] = data[j-1];
				data[i] = element;
				inserted = true;
				break;
			}
		}
		if (!inserted)
			data[size] = element;
		size++;
		return true;
	}

	public T this[int index] {
		get {
			if (index < 0 || index >= size)
				throw new System.ArgumentOutOfRangeException();
			return data[index];
		}
		set {
			if (index < 0 || index >= size)
				throw new System.ArgumentOutOfRangeException();
			data[index] = value;
		}
	}
}
