using System;
class ResidPattern {
    static double Vat(string country) => country switch {
        "Deutschland" => 19.0,
        "Frankreich" => 20.0,
        "Luxemburg" => 17.0,
        _ => Double.NaN
        //var cvar => throw new ArgumentException("Unknown Country: " + cvar)
        //_ => throw new ArgumentException("Unknown Country: " + country)
        //var cvar => cvar != null ?
        //   throw new ArgumentException("Unknown Country: " + cvar) :
        //   throw new ArgumentException("No argument")
        //null => throw new ArgumentException("No argument")
        //{} => throw new ArgumentException("Unknown Country: " + country)
    };

    static void Main() {
        string country = "Lichtenstein";
        //country = null;
        try {
            Console.WriteLine("Value added tax: " + Vat(country));
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
