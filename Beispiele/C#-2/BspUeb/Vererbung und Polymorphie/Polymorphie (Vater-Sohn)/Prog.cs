using System;
class Prog {
	static void Main() {
		Vater[] varray = new Vater[3];
		varray[0] = new Vater();
		varray[1] = new Sohn();
		varray[0].Hallo();
		varray[1].Hallo();

        //((Sohn)varray[0]).NurSo();
        //if (varray[1] is Sohn)
        //    ((Sohn)varray[1]).NurSo();
		
		Console.Write("\nWollen Sie zum Abschluss noch einen"+
		 " Vater oder einen Sohn erleben?"+
		 "\nWählen Sie durch Abschicken von \"v\" oder \"s\": ");
		if (Console.ReadLine().ToUpper()[0] == 'V')
			varray[2] = new Vater();
		else
			varray[2] = new Sohn();
		Console.WriteLine();
		varray[2].Hallo();
        Console.ReadLine();
	}
}
