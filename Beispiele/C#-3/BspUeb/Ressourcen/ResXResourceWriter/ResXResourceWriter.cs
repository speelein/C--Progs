using System;
using System.Drawing;
using System.Resources;

class ResXResourceWriterDemo {
	static void Main() {
		ResXResourceWriter rsxw = new ResXResourceWriter("mpc.resx");
		rsxw.AddResource("TitelText", "Multi Purpose Counter");
		rsxw.AddResource("Count", new Bitmap("count.bmp"));
		rsxw.AddResource("Reset", new Bitmap("reset.bmp"));
		rsxw.Close();
		Console.WriteLine("Fertig!"); Console.ReadLine();
	}
}
