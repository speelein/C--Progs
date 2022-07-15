class PersonDB {
    int n;
    Person first, last;

    public int N {
        get {
            return n;
        }
    }

    public PersonDB(string vorname, string name) {
        first = last = new Person(vorname, name);
        n = 1;
    }

    public void Add(string vorname, string name) {
        Person neu = new Person(vorname, name);
        last.Next = neu;
        last = neu;
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
            if (i >= 0 && i < n) {
                Person sel = first;
                for (int j = 0; j < i - 1; j++)
                    sel = sel.Next; // Vorgänger
                value.Next = sel.Next.Next;
                sel.Next = value;
            }
        }
    }
}
