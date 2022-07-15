using System;
using System.Runtime.Serialization;

public struct SecDepot {
	int nr;
	int betrag;
	public SecDepot(int nr_, int betrag_) {
		nr = nr_;
		betrag = betrag_;
	}
	public int Nr { get { return nr; } }
	public int Betrag { get { return betrag; } }
}

[Serializable]
public class Kunde {
    int nr;
    string vorname;
    string name;
	[NonSerialized]
	int stimmung;
	int nkaeufe;
	double aussen;
	// Mit diesem Attribut kann die SerializationException verhindert werden: [NonSerialized]
	SecDepot sd;
    public Kunde(int nr_, string vorname_, string name_, int stimmung_,
	             int nkaeufe_, double aussen_, int nr, int betrag) {
        nr = nr_;
        vorname = vorname_;
		name = name_;
        stimmung = stimmung_;
		nkaeufe = nkaeufe_;
		aussen = aussen_;
		sd = new SecDepot(nr, betrag);
	}
	public void Prot() {
        Console.WriteLine("Kundennummer: \t" + nr);
        Console.WriteLine("Name: \t\t" + vorname + " " + name);
		Console.WriteLine("Stimmung: \t" + stimmung);
		Console.WriteLine("Anz.Einkäufe: \t" + nkaeufe);
		Console.WriteLine("Aussenstände: \t" + aussen+ "\n");
	}
}
