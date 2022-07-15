class PersonDB {
    int n;
    Person first, last;

	public int Count {
		get {
			return n;
		}
	}

    public void Add(Person neu) {
		if (n == 0)
			first = last = neu;
		else {
			last.Next = neu;
			last = neu;
		}
        n++;
    }

    public Person this[int i] {
        get {
            if (i >= 0 && i < n) {
                Person sel = first;
                for (int j = 0; j < i; j++)
                    sel = sel.Next;
                return sel;
            } else
                return null;
        }
        set {
            if (i >= 0 && i < n && value != null) {
                Person sel = first;
                for (int j = 0; j < i - 1; j++)
                    sel = sel.Next;
				value.Next = sel.Next.Next; // Nachfolger des Neulings
				sel.Next = value; // Vorgänger des Neulings
            }
        }
    }
}
