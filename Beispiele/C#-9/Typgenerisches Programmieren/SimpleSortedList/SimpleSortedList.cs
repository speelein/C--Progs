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

	// Diese Methode wurde durch Paul Frischknecht entscheidend verbessert.
	public void Add(T element) {
		if (size == data.Length)
			throw new System.InvalidOperationException("Kapazität erschöpft");
		int i;
		for (i = size - 1; i >= 0 && element.CompareTo(data[i]) < 0; i--)
			data[i + 1] = data[i];
		data[i + 1] = element;
		size++;
	}

	public int Count {
		get => size;
    }

	public T this[int index] {
		get {
			if (index < 0 || index >= size)
				throw new System.ArgumentOutOfRangeException();
			return data[index];
		}
	}
}
