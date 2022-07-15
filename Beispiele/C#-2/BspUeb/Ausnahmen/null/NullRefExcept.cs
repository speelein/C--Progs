using System;

class NullRefExcept {
	static void Main() {
		int[] vek = new int[5];
		vek = null;
		vek[0] = 1;
	}
}

