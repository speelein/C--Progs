using System;
//public struct Punkt : IComparable {
//	double xpos, ypos;
//	public Punkt(double x, double y) {
//		xpos = x; ypos = y;
//	}
//	public int CompareTo(object v) {
//		Punkt vergl = (Punkt)v;
//		if (xpos < vergl.xpos)
//			return -1;
//		else
//			if (xpos > vergl.xpos)
//			return 1;
//		return 0;
//	}
//}

public struct Punkt : IComparable<Punkt> {
	double xpos, ypos;
	public Punkt(double x, double y) {
		xpos = x; ypos = y;
	}
	public int CompareTo(Punkt vergl) {
		if (xpos < vergl.xpos)
			return -1;
		else
			if (xpos > vergl.xpos)
			return 1;
		return 0;
	}
}
