using System;
using System.Runtime.Serialization;

[Serializable]
public class Kunde {
    int nr;
    string vorname;
    string name;
	[NonSerialized]
	int stimmung;
	int nkaeufe;
	double aussen;
    public Kunde(int nr_, string vorname_, string name_, int stimmung_,
	             int nkaeufe_, double aussen_) {
        nr = nr_;
        vorname = vorname_;
		name = name_;
        stimmung = stimmung_;
		nkaeufe = nkaeufe_;
		aussen = aussen_;
	}
	public void Prot() {
        Console.WriteLine("Kundennummer: \t" + nr);
        Console.WriteLine("Name: \t\t" + vorname + " " + name);
		Console.WriteLine("Stimmung: \t" + stimmung);
		Console.WriteLine("Anz.Einkäufe: \t" + nkaeufe);
		Console.WriteLine("Aussenstände: \t" + aussen+ "\n");
	}
}
