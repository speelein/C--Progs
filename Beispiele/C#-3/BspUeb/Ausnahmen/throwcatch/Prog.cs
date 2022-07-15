using System;
class Prog {
	static void Nix(bool cond) {
		try {
			if (cond)
				throw new Exception("A");
			else
				throw new Exception("B");
		}
		catch (Exception e) {
			Console.WriteLine(e.Message);
		}	
	}
	static void Main() {
		Nix(true);
        Console.ReadLine();
	}
}
