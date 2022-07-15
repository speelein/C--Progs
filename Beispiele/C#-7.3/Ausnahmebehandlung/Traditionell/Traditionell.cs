using System;

class TraditionelleAusnahmebehandlung {
	static int M1() {
		return 0;
	}
    static int M2() {
        return 0;
    }
    static int M3() {
        return 0;
    }
static void Main() {
    int returncode;
    returncode = M1();
    // Behandlung von potentiellen M1() - Fehlern
    if (returncode == 1) {
        // ...
        Environment.Exit(11);
    }
    // ...

    returncode = M2();
    // Behandlung von potentiellen M2() - Fehlern
    if (returncode == 1) {
        // ...
        Environment.Exit(21);
    }
    // ...

    returncode = M3();
    // Behandlung von potentiellen M3() - Fehlern
    if (returncode == 1) {
        // ...
        Environment.Exit(31);
    }
    // ...
}
}
