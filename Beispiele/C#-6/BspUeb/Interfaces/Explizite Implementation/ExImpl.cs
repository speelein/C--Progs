public interface I1 {
	int M();
}
public interface I2 {
	int M();
}
public class K : I1, I2 {
	int I1.M() {
		return 13;
	}
	int I2.M() {
		return 4711;
	}
}

