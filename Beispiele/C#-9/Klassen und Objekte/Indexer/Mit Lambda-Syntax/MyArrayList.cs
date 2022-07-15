using System;
class MyArrayList {
    private object[] store = new object[100];
    int next = 0;

    public object this[int i] {
        get => store[i];
        set => store[i] = value;
    }

    //public object this[int i] {
    //    get { return store[i]; }
    //    set { store[i] = value; }
    //}

    public void Add(object value) {
        if (next >= store.Length)
            throw new IndexOutOfRangeException($"Max. {store.Length} Elemente erlaubt.");
        store[next++] = value;
    }
}
