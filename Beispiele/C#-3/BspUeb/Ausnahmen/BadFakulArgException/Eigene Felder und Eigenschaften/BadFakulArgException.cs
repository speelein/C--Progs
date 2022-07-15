using System;

public sealed class BadFakulArgException : Exception {
	int type, value;
	string input;
	public BadFakulArgException() {
	}
	public BadFakulArgException(String message) : base(message) {
	}
	public BadFakulArgException(String message, Exception innerException)
		: base(message, innerException) {
	}
	public BadFakulArgException(string message, string input_,
								int type_, int value_)
		: this(message, input_, type_, value_, null) {
	}
	public BadFakulArgException(string message, string input_,
								int type_, int value_, Exception innerException)
			: this(message, innerException) {
		input = input_;
		type = type_;
		value = value_;
	}
	public string Input {get {return input;}}
	public int Type {get {return type;}}
	public int Value {get {return value;}}
}
