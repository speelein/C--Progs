using System;

class AnonClass {
	static void Main() {
		var a=new{Name="Knut",Alter=53};
		Console.WriteLine(a.GetType());

		int Alter = 53;
		var b = new {Name = "Knut", Alter};
		Console.WriteLine(b.Alter.GetType());
		Console.ReadLine();
	}
}