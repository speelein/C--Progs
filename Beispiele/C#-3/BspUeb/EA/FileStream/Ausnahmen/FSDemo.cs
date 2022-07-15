using System;
using System.IO;

class FSDemo {
	static void Main() {
		String name = "demo.bin";
		byte[] arr = {0,1,2,3,4,5,6,7};
		try {
			using (FileStream fs = new FileStream(name, FileMode.Create)) {
				fs.Write(arr, 0, arr.Length);
				fs.Position = 0;
				fs.Read(arr, 0, arr.Length);
				foreach (byte b in arr)
					Console.WriteLine(b);
			}
			File.Delete(name);
		} catch (Exception e) {
			Console.WriteLine(e);
		}
		Console.ReadLine();
	}
}
