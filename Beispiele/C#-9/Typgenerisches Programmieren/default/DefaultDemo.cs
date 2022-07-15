using System;

struct MitNullInt {
	int i;
	int? inu;
	public MitNullInt(int i, int? inu) {
		this.i = i;	this.inu = inu;
	}
	public override String ToString() {
		return "(" + i + ", " + (inu == null ? "null" : inu.ToString()) + ")";
	}
}

class DefaultDemo {
	static void WriteDef<T>() {
		Console.Write("default of " + typeof(T) + ": ");
        if (default(T) == null)
            Console.WriteLine("null");
        else
            Console.WriteLine(default(T));
	}
	static void Main() {
		WriteDef<int>();
		WriteDef<System.Numerics.Complex>();
		WriteDef<String>();
		WriteDef<int?>();
		WriteDef<MitNullInt>();
	}
}
