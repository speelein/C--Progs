using System.Collections;
using System.Collections.Generic;

public class SimpleSortedList<T> : IEnumerable<T> where T : System.IComparable<T> {
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

	public void Add(T element) {
		if (size == data.Length)
			throw new System.InvalidOperationException("Kapazität erschöpft");
		int i;
		for (i = size - 1; i >= 0 && element.CompareTo(data[i]) < 0; i--)
			data[i + 1] = data[i];
		data[i + 1] = element;
		size++;
	}

	public T this[int index] {
		get {
			if (index < 0 || index >= size)
				throw new System.ArgumentOutOfRangeException();
			return data[index];
		}
	}

	public IEnumerator<T> GetEnumerator() {
		for (int i = 0; i < size; i++)
			yield return data[i];
	}

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public IEnumerable<T> RangeIt(int first, int last) {
		if (first < 0 || last >= size)
			yield break;
		for (int i = first; i <= last; i++)
			yield return data[i];
	}

	public IEnumerable<T> RangeItUpDown(int first, int last, int direction = 1) {
		if (first < 0 || last >= size)
			yield break;
		if (first <= last && direction == 1)
			for (int i = first; i <= last; i++)
				yield return data[i];
		if (first >= last && direction == 2)
			for (int i = first; i >= last; i--)
				yield return data[i];
	}

	public IEnumerable<T> DownIt {
		get {
			for (int i = size - 1; i >= 0; i--)
				yield return data[i];
		}
	}

}
