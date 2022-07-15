using System;

class Familie {
	string name;
	Tochter t;
	Sohn s;

	public Familie(string name_, int ato, int aso) {
		name = name_;
		t = new Tochter(this, ato);
		s = new Sohn(this, aso);
	}

	public void Info() {
		Console.WriteLine("Die Kinder von Familie {0}:\n", name);
		t.Info();
		s.Info();
	}

	static void Main() {
		Familie f = new Familie("Müller", 7, 4);
		f.Info();
        Console.ReadLine();
	}

	class Tochter {
		Familie f;
		int alter;

		public Tochter(Familie f_, int altpar) {
			f = f_;
			alter = altpar;
		}

		public void Info() {
			Console.WriteLine("  Ich bin die {0}-jährige Tochter von Familie {1}",
                              alter, f.name);
		}
	}

	class Sohn {
		Familie f;
		int alter;

		public Sohn(Familie f_, int altpar) {
			f = f_;
			alter = altpar;
		}

		public void Info() {
			Console.WriteLine("  Ich bin der {0}-jährige Sohn von Familie {1}",
                              alter, f.name);
		}
	}
}
