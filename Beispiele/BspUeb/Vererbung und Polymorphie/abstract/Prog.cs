using System;
class Prog {
	static void Main() {
		Vater[] varray = new Vater[2];
		varray[0] = new Tochter();
		varray[1] = new Sohn();
		varray[0].Hallo();
		varray[1].Hallo();
	}
}
