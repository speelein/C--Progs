using System;

public class BadFaculArgException : Exception {
	int type, value = -1;
	string input;

	public BadFaculArgException() {
	}
	public BadFaculArgException(string message) : base(message) {
	}
	public BadFaculArgException(string message, Exception innerException)
		: base(message, innerException) {
	}
	public BadFaculArgException(string message, string input_,
								int type_, int value_)
		: this(message, input_, type_, value_, null) {
	}
	public BadFaculArgException(string message, string input_,
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

	public string Input {get {return input;}}
	public int Type {get {return type;}}
	public int Value {get {return value;}}
}
