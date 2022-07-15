using System;

public class BadFaculArgException : Exception {
    public BadFaculArgException() {
    }
    public BadFaculArgException(String message) : base(message) {
    }
    public BadFaculArgException(String message, Exception innerException)
        : base(message, innerException) {
    }
}
