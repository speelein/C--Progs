using System;

readonly public struct Strecke {
    readonly public int li, re;
    public Strecke(int li, int re) {
        this.li = li; this.re = re;
    }
}

class StreckenSammlung {
    const int K = 10, MAX = 100;
    public Strecke[] Strecken;
    public Strecke NF = new Strecke(-1, -1);

    public StreckenSammlung() {
        Strecken = new Strecke[K];
        Random zzg = new Random();
        for (int i = 0; i < K; i++) {
            int start = zzg.Next(MAX-5);
            Strecken[i] = new Strecke(start, start+5);
        }
    }

    public ref Strecke FindeStrecke(int x) {
        for (int i = 0; i < K; i++)
            if (x >= Strecken[i].li && x <= Strecken[i].re)
                return ref Strecken[i];
        return ref NF;
    }
}

class Prog {
    static StreckenSammlung strKoll = new StreckenSammlung();
    static void Main() {
        ref Strecke strecke = ref strKoll.FindeStrecke(12);
        //Strecke strecke = strKoll.FindeStrecke(12); // Übergabe einer Kopie
        if (strecke.li != -1)
            Console.WriteLine("Treffer in (" + strecke.li + ", " + strecke.re + ")");
        else
            Console.WriteLine("Kein Treffer");
    }
}
