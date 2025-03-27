namespace CW2_apbd;

public abstract class Kontener
{
    private static int _counter;

    public double MasaLadunku { get; set; }
    public double Wysokosc { get; set; }
    public double Glebokosc { get; set; }
    public double WagaWlasna { get; set; }
    public double MaxLadownosc { get; set; }
    public string NumerSeryjny { get; set; }


    protected Kontener(double wysokosc, double glebokosc, double wagaWlasna, double maxLadownosc)
    {
        Wysokosc = wysokosc;
        Glebokosc = glebokosc;
        WagaWlasna = wagaWlasna;
        MaxLadownosc = maxLadownosc;
        MasaLadunku = 0;
    }


    protected string GenerujNumerSeryjny(char typKonteneru)
    {
        return $"KON-{typKonteneru}-{++_counter}";
    }

    public virtual void OproznijLadunek()
    {
        MasaLadunku = 0.0;
    }

    public virtual void ZaladujKontener(double masa)
    {
        if (MasaLadunku + masa > MaxLadownosc)
            throw new OverfillException(this);
        MasaLadunku += masa;
    }


    public virtual void WypiszInformacje()
    {
        Console.WriteLine($"Kontener o numerze seryjnym: {NumerSeryjny}");
        Console.WriteLine($"Masa ladunku: {MasaLadunku} kg");
        Console.WriteLine($"Wysokosc: {Wysokosc} cm");
        Console.WriteLine($"Waga wlasna kontenera: {WagaWlasna} kg");
        Console.WriteLine($"Glebokosc: {Glebokosc} cm");
        Console.WriteLine($"Max ladownosc: {MaxLadownosc} kg");
    }
}