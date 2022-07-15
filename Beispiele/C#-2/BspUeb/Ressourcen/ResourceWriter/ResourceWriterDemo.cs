using System;
using System.Drawing;
using System.Resources;

class ResourceWriterDemo {
	static void Main() {
		ResourceWriter rsw = new ResourceWriter("mpc.resources");
		rsw.AddResource("TitelText", "Multi Purpose Counter");
		rsw.AddResource("Count", new Bitmap("count.bmp"));
		rsw.AddResource("Reset", new Bitmap("reset.bmp"));
		Console.WriteLine("Fertig!"); Console.ReadLine();
		rsw.Close();
	}
}