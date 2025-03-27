namespace CW2_apbd;

public class KontenerNaGaz : Kontener, IHazardNotifier
{
    public double Cisnienie { get; set; }


    public KontenerNaGaz(double wysokosc, double glebokosc, double wagaWlasna, double maxLadownosc, double cisnienie) :
        base(wysokosc, glebokosc, wagaWlasna, maxLadownosc)
    {
        Cisnienie = cisnienie;
        NumerSeryjny = GenerujNumerSeryjny('G');
    }

    public override void OproznijLadunek()
    {
        MasaLadunku *= 0.05;
    }

    public override void ZaladujKontener(double masa)
    {
        if (MasaLadunku + masa > MaxLadownosc)
        {
            PoinformujOProbieWykonaniaNiebezpiecznejOperacji(NumerSeryjny);
            throw new OverfillException(this);
        }

        MasaLadunku += masa;
    }

    public override void WypiszInformacje()
    {
        base.WypiszInformacje();
        Console.WriteLine($"Cisnienie: {Cisnienie}");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine();
    }

    public void PoinformujOProbieWykonaniaNiebezpiecznejOperacji(string numerSeryjny)
    {
        Console.WriteLine(
            "UWAGA[GAZ] - Doszlo do proby wykonania niebezpiecznej operacji. Numer seryjny konteneru, którego sytuacja dotyczy: " +
            numerSeryjny);
    }
}