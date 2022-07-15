public class SimpleStack<T> {
	int capacity = 5;
    T[] data;
	int size;

	public SimpleStack() {
		data = new T[capacity];
	}

    public SimpleStack(int max) {
		if (max > 0)
			capacity = max;
		data = new T[capacity];
	}

	public int Count {
		get { return size; }
	}

	public bool Push(T element) {
		if (size < capacity) {
			data[size++] = element;
			return true;
		} else
			return false;
	}

	public T Pop() {
		if (size > 0)
			return data[--size];
		else
			throw new System.InvalidOperationException();
	}
}
