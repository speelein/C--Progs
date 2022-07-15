using System;

public sealed class BadFakulArgException : Exception {
	public BadFakulArgException() {
	}
	public BadFakulArgException(String message) : base(message) {
	}
	public BadFakulArgException(String message, Exception innerException)
		: base(message, innerException) {
	}
}
