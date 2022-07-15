using System;

public class BadFakulArgException : ApplicationException {
	protected int fehlerTyp, wert;
	protected string eingabeString;
	public BadFakulArgException(string fehlerMeldung, string eingabeString_,
                                int fehlerTyp_, int wert_)
			: base(fehlerMeldung) {
		eingabeString = eingabeString_;
		fehlerTyp = fehlerTyp_;
		wert = wert_;
	}
	public string Eingabe {get {return eingabeString;}}
	public int FehlerTyp {get {return fehlerTyp;}}
	public int Wert {get {return wert;}}
}
