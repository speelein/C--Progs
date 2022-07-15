class PersonDB {
    int n;
    Person first, last;

	public int Count {
		get {
			return n;
		}
	}

	public void Add(Person neu) {
		if (neu == null)
			return;
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
				if (i == 0) {
					value.Next = first.Next; // Nachfolger des Neulings
					first = value; // Der Neuling wird "Leader"
				} else {
					Person pre = first;
					for (int j = 0; j < i - 1; j++)
						pre = pre.Next;
					value.Next = pre.Next.Next; // Nachfolger des Neulings
					pre.Next = value; // Vorgänger des Neulings
				}
			}
		}
	}

	// Indexer können überladen werden.
    public Person this[string vn] {
	    get {
            for (int j = 0; j < n; j++)
                if (this[j].Vorname == vn)
                    return this[j];
		    return null;
	    }
    }
}
