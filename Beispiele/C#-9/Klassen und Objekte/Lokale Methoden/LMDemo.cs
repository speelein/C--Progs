using System;
class LMDemo {
    static readonly int staticField = 1;
    readonly int field = 2;

    int M() {
        int local = 3;
        int LM() => staticField + field + local;
        return LM();
        //static int SLM() => staticField + field + local;
        //return SLM();
    }

    static void Main() {
        LMDemo p = new LMDemo();
        Console.WriteLine(p.M());
    }
}

