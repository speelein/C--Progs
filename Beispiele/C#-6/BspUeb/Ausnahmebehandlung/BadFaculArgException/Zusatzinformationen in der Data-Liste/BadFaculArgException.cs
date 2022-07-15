using System;

public class BadFakulArgException : Exception {
	int type, value = -1;
	String input;

	public BadFakulArgException() {
	}
	public BadFakulArgException(String message) : base(message) {
	}
	public BadFakulArgException(String message, Exception innerException)
		: base(message, innerException) {
	}
	public BadFakulArgException(String message, String input_,
								int type_, int value_)
		: this(message, input_, type_, value_, null) {
	}
	public BadFakulArgException(String message, String input_,
								int type_, int value_, Exception innerException)
			: base(message, innerException) {
		input = input_;
		if (type_ >= 0 && type <= 3)
			type = type_;
		if (type_ == 4 && (value_ < 0 || value_ > 170)) {
			type = type_;
			value = value_;
		}
	}

	public String Input {get {return input;}}
	public int Type {get {return type;}}
	public int Value {get {return value;}}
}
